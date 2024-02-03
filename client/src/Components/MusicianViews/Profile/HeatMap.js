import CalendarHeatmap from 'react-calendar-heatmap';
import "./HeatMap.css";
import { useEffect, useState } from 'react';

const today = new Date();

export const HeatMap = ({ dates }) => {
    const [dateValues, setDateValues] = useState([]);

    useEffect(() => {
        setDateValues(dates.map(d => formatDates(d)));
    }, [dates])

    console.log(dateValues);

  const datesValues = getRange(200).map(index => {
    let date = shiftDate(today, -index);
    let count = dateValues.includes(date) ? 1 : 0;
    return {
      date: date,
      count: count
    };
  });

  const formatDates = (arr) => {
    for(let a of arr)
    {
        return {
            date: new Date(a),
        }
    }
  }

  

  return (
    <div className='heat-map-container'>
        {console.log('dates', dates)}
        {console.log('datesValues', datesValues)}
        <CalendarHeatmap
            gutterSize={2} //gap between boxes
            startDate={shiftDate(today, -180)} //last 180 days
            endDate={today}
            values={datesValues}
            classForValue={value => {
                if (value.count === 0) {
                    return 'color-empty';
                }
                return 'color-filled';
            }}
            onClick={value => alert(`Clicked on value with count: ${value.count}`)}
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

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

