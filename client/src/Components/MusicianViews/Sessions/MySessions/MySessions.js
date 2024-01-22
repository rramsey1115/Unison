import "./MySessions.css";
import plusIcon from "../../../../images/plus-icon.png";
import removeIcon from "../../../../images/remove-icon.png";
import { useEffect, useState } from "react";
import { getAllSessions } from "../../../../Managers/sessionManager";

export const MySessions = ({ loggedInUser }) => {
    const [sessions, setSessions] = useState([]);
    const userId = loggedInUser.id;

    useEffect(() => { getAndSetSessions() }, [userId])

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId === userId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.categoryId - b.activity.categoryId
              });
            setSessions(filtered);
        });
    }

    const getFormattedDate = (dateString) => {
        const date = new Date(dateString); // {object Date}
        const yyyy = date.getFullYear();
        let mm = date.getMonth() + 1;
        let dd = date.getDate();
        if (dd < 10) dd = "0" + dd;
        if (mm < 10) mm = "0" + mm;
        const formatted = mm + "/" + dd + "/" + yyyy;
        return formatted;
    };

    return (
        <section className="sessions-container">
            <header className="sessions-header">
                <h1>{loggedInUser.firstName}'s Sessions</h1>
            </header>

            <section className="sessions-body">

                <div id="create-session-div">
                    <img id="plus-icon" className="plus-icon" alt="plus icon" src={plusIcon}/>
                </div>

                {/* returns card for each session */}
                {sessions.map(s => {
                    return( 
                    <div key={s.id} className="session-div">
                        <div className="session-div-header">
                            <h4 id="session-div-header-date">{getFormattedDate(s.dateCompleted)}</h4>
                            <img id="remove-icon" className="remove-icon" alt="remove icon" src={removeIcon}/>
                        </div>
                        
                        <h5>{s.duration} Minutes</h5>
                        
                        {s.sessionActivities.map(a => {
                            return ( 
                            <div className="session-div-activities" key={a.id}>
                                <h5 >{a.activity.category.name}</h5>
                                <p>{a.activity.name}</p>
                            </div>)}
                        )}
                        <div className="session-div-notes">
                            <h5>Notes</h5>
                            <p>{s.notes}</p>
                        </div>
                        
                    </div> 
                )})}

            </section>

        </section>
    )
}