import { useEffect, useState } from "react"
import { getAllSessions } from "../../../Managers/sessionManager";

export const LastSession = ({studentId}) => {
    const [lastSession, setLastSession] = useState([]);

    useEffect(() => { getAndSetSessions() }, [studentId])

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId == studentId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.dateCompleted - b.activity.dateCompleted
              });
              if(filtered.length > 0)
              {
                setLastSession(filtered[0]);
              }
        });
    };

    return(
        lastSession?.length === 0 
        ? <p>{"--/--/----"}</p> 
            // if the last practice session was more than 7 days ago, make the text color red
        : (new Date(lastSession.dateCompleted).getTime() < (Date.now() - 7 * 24 * 60 * 60 * 1000)) ?
            <p style={{color:"red", margin:0}}>{new Date(lastSession.dateCompleted).toLocaleDateString()}</p>
        : <p style={{margin:0}}>{new Date(lastSession.dateCompleted).toLocaleDateString()}</p>
    );
}