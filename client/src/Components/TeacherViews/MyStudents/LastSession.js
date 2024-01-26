import { useEffect, useState } from "react"
import { getAllSessions } from "../../../Managers/sessionManager";

export const LastSession = ({studentId}) => {
    const[lastSession, setLastSession] = useState([]);

    useEffect(() => { getAndSetSessions() }, [studentId])

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId == studentId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.dateCompleted - b.activity.dateCompleted
              });
            setLastSession(filtered[0]);
        });
    };

    return(
    lastSession.length === 0 
    ? <>{"--/--/----"}</> 
    : <>{new Date(lastSession.dateCompleted).toLocaleDateString()}</>
    );
}