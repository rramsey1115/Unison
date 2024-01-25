import { useEffect, useState } from "react"
import { getAllSessions } from "../../../Managers/sessionManager";

export const LastSession = ({studentId}) => {
    const[lastSession, setLastSession] = useState([]);

    useEffect(() => { getAndSetSessions() }, [student])

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId === student.id && d.dateCompleted !== null);
            // filtered ?? filtered.sessionActivities.sort(function(a, b) { 
            //     return a.activity.categoryId - b.activity.categoryId
            //   });
            console.log(filtered);
            setLastSession(filtered);
        });
    };

    console.log('lastSessionDate', lastSession);

    return(
        <p>session date</p>
    )
}