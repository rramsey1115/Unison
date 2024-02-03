import CalendarHeatmap from 'react-calendar-heatmap';
import "./HeatMap.css";

const today = new Date();

export const HeatMap = () => {

  const randomValues = getRange(200).map(index => {
    return {
      date: shiftDate(today, -index),
      count: getRandomInt(0, 1),
    };
  });

  return (
    <div className='heat-map-container'>
        <CalendarHeatmap
            startDate={shiftDate(today, -180)}
            endDate={today}
            values={randomValues}
            classForValue={value => {
            if (value.count === 0) {
                return 'color-empty';
            }
            // return `color-${value.count}`;
            return 'color-filled';
            }}
            // showWeekdayLabels={true}
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

