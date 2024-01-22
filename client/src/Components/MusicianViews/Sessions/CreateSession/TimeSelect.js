import { useState } from "react"

export const TimeSelect = ({time, setTime}) => {

    return(
        <select 
            id="time-dropdown" 
            className="dropdown"
            onChange={(e) => setTime(e.target.value)}
        >
            <option>Minutes</option>
            {Array.from({ length: 60 }, (_, index) => (
                <option 
                    key={index+1} 
                    value={index+1}
                >{index+1}
                </option>
            ))}
        </select>
    )
}