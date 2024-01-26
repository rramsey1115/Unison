import "../../../Components/MusicianViews/Sessions/MySessions/MySessions.css";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { getAllSessions } from "../../../Managers/sessionManager";
import { getAllComments } from "../../../Managers/commentManager";
import plusIcon from "../../../images/plus-icon.png";

export const StudentSessions = ({ loggedInUser }) => {
    const [sessions, setSessions] = useState([]);
    const [comments, setComments] = useState([]);
    const studentId = useParams().id*1;
    const userId = loggedInUser.id*1;

    console.log('studentId', studentId);
    console.log('userId', userId);

    useEffect(() => { getAndSetSessions(); getAndSetComments(); }, [userId]);

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId === studentId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.categoryId - b.activity.categoryId
              });
            setSessions(filtered);
        });
    };

    const getAndSetComments = () => {
        getAllComments().then(setComments);
    };

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

    const navigate = useNavigate();

    return (
        <section className="sessions-container">
            <header className="sessions-header">
                <h1>{loggedInUser.firstName}'s Sessions</h1>
            </header>
            <section className="sessions-cards">
                <div id="create-session-div" onClick={(e) => navigate('create')}>
                    <img id="plus-icon" className="plus-icon" alt="plus icon" src={plusIcon}/>
                </div>
                {/* returns card for each session */}
                {sessions.map(s => {
                    // sets comments for this session - if null handled below
                    var arr = comments.filter(c => c.sessionId === s.id);

                    return( 
                    <div key={s.id} className="session">
                        <div key={s.id} className="session-div">
                            <div className="session-div-header">
                                <h4 id="session-div-header-date">{getFormattedDate(s.dateCompleted)}</h4>
                            </div>
                            <h5>{s.duration} Minutes</h5>
                            {s.sessionActivities.map(a => {
                                return (
                                <div id="session-div-activities" className="session-card" key={a.id}>
                                    <h5 >{a.activity.category.name}</h5>
                                    <p>{a.activity.name}</p>
                                </div>)}
                            )}
                            <div className="session-div-notes">
                                <h5>My Notes</h5>
                                <p>{s.notes}</p>
                            </div>
                                

                            <div className="session-div-comments">
                                <h5>Teacher Comments</h5>
                                {arr.length > 0 
                                ? arr.map(a => {
                                    return (
                                        <p key={a.id}>From: {a.teacher.lastName}<br/>{a.body}</p>
                                    )})
                                : <p>None at this time</p>}
                            </div>
                        </div>
                        <div className="session-div-btns">
                            
                        </div>
                    </div>
                )})}
            </section>
        </section>
    );
}