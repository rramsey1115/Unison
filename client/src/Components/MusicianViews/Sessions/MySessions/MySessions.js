import "./MySessions.css";
import { useNavigate } from "react-router-dom";
import plusIcon from "../../../../images/plus-icon.png";
import filledFav from "../../../../images/filled-favorite.png"
import repeatIcon from "../../../../images/start.png";
import emptyFav from "../../../../images/empty-favorite.png"
import { useEffect, useState } from "react";
import { deleteSessionById, getAllSessions } from "../../../../Managers/sessionManager";
import { getFavoritesByMusicianId } from "../../../../Managers/favoriteSessionsManager";
import { ConfirmDeleteModal } from "./ConfirmDeleteModal";
import { getAllComments } from "../../../../Managers/commentManager";

export const MySessions = ({ loggedInUser }) => {
    const [favoriteSessions, setFavoriteSessions] = useState([]);
    const [sessions, setSessions] = useState([]);
    const [comments, setComments] = useState([]);
    const userId = loggedInUser.id;

    useEffect(() => { getAndSetSessions(); getAndSetFavoriteSessions(userId); getAndSetComments(); }, [userId]);

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId === userId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.categoryId - b.activity.categoryId
              });
            setSessions(filtered);
        });
    };

    const getAndSetFavoriteSessions = () => {
        getFavoritesByMusicianId(userId).then(data =>setFavoriteSessions(data));
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

    const handleDeleteSession = (id) => {
        deleteSessionById(id).then(() => getAndSetSessions()).then(() => getAndSetFavoriteSessions());
    };

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
                            {favoriteSessions.length > 0 ? favoriteSessions?.map(fs => {
                                if(s.id === fs.sessionId )
                                {
                                    return <img 
                                        key={s.id} 
                                        id="favorite-icon" 
                                        className="favorite-icon" 
                                        alt="favorite icon" 
                                        src={filledFav}
                                    />
                                }
                                else
                                {
                                    return <img 
                                        key={s.id} 
                                        id="favorite-icon" 
                                        className="favorite-icon" 
                                        alt="favorite icon" 
                                        src={emptyFav}
                                    />
                                }
                            })
                            : 
                            <img 
                                key={s.id} 
                                id="favorite-icon" 
                                className="favorite-icon" 
                                alt="favorite icon" 
                                src={emptyFav}
                            />
                            
                            }

                            {/* Comment this back in once I have functionality to redo a session */}
                            {/* <img 
                                id="repeat-icon" 
                                className="repeat-icon" 
                                alt="repeat icon" 
                                src={repeatIcon}
                            /> */}

                            <ConfirmDeleteModal session={s} handleDeleteSession={handleDeleteSession} getFormattedDate={getFormattedDate}/>
                            
                        </div>
                    </div>
                )})}
            </section>
        </section>
    );
}