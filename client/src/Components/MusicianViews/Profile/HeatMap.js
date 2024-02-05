import CalendarHeatmap from 'react-calendar-heatmap';
import "./HeatMap.css";
import { useEffect, useState } from 'react';
import { ScaleLoader } from 'react-spinners';
import { Alert } from 'reactstrap';

const today = new Date();

export const HeatMap = ({ dates }) => {
    const [dateValues, setDateValues] = useState([]);
    const [values, setValues] = useState([]);
    const [alert, setAlert] = useState(false);
    const [selectedDate, setSelectedDate] = useState(null);
    const [practiced, setPracticed] = useState(null);

    const onDismiss = () => setAlert(false);

    useEffect(() => {
        setDateValues(formatDates(dates))
    }, [dates])

    useEffect(() => {
        // compares existing practice dates to an array of 180 dates... matches heatMap length;
        const arr = getRange(90).map(index => {
            let date = shiftDate(today, -index);
            
            let count = dateValues.some(d => {
                // sets all dateTimes to base time, since we only care about the year, month, day
                const dateWithoutTime = new Date(d.date);
                dateWithoutTime.setHours(0, 0, 0, 0);
            
                const currentDateWithoutTime = new Date(date);
                currentDateWithoutTime.setHours(0, 0, 0, 0);
                // compares dates to see if a practice session occured on that date
                return dateWithoutTime.getTime() === currentDateWithoutTime.getTime();
            }) ? 1 : 0;
            //object needed for HeatCalendarMap - has ability to show multiple values per date, but we only care about 1 or 0
            return {
                date: date,
                count: count
            };
        });
        setValues(arr);
    }, [dateValues]);

    const handleClick = (value) => {
        // sets the date for alert
        setSelectedDate(value.date);
        // sets the color for alert
        if(value.count === 0){setPracticed(false)}
        if(value.count === 1){setPracticed(true)}
        //opens alert
        setAlert(true);
      };

    return (
    !values.length
    ?
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <div className='heat-map-container'>
            <Alert color={practiced===false ? "danger" : "info"} fade isOpen={alert} toggle={onDismiss}>
                {selectedDate && practiced===true ? `Practiced on ${selectedDate.toLocaleDateString()}`
                : selectedDate && `Did not practice on ${selectedDate.toLocaleDateString()}` }
            </Alert>
            <CalendarHeatmap
                gutterSize={2} //gap between boxes
                startDate={shiftDate(today, -90)} //last 180 days
                endDate={today}
                values={values}
                classForValue={value => {
                    if (value.count === 0) {
                        return 'color-empty';
                    }
                    return 'color-filled';
                }}
                onClick={(e) => handleClick(e)}
            />
        </div>
    );
}

function shiftDate(date, numDays) {
    const newDate = new Date(date);
    newDate.setDate(newDate.getDate() + numDays);
    return newDate;
}

function getRange(count) {
    return Array.from({ length: count }, (_, i) => i);
}

const formatDates = (arr) => {
    var res = [];
    for(let a of arr)
    {
        res.push({date: new Date(a)}) 
    }
    return res;
}