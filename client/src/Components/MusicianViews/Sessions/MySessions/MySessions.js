import "./MySessions.css";
import plusIcon from "../../../../images/plus-icon.png";
import filledFav from "../../../../images/filled-favorite.png"
import deleteIcon from "../../../../images/delete.png";
import repeatIcon from "../../../../images/start.png";
import emptyFav from "../../../../images/empty-favorite.png"
import { useEffect, useState } from "react";
import { getAllSessions } from "../../../../Managers/sessionManager";
import { getFavoritesByMusicianId } from "../../../../Managers/favoriteSessionsManager";

export const MySessions = ({ loggedInUser }) => {
    const [favoriteSessions, setFavoriteSessions] = useState([]);
    const [sessions, setSessions] = useState([]);
    const userId = loggedInUser.id;

    useEffect(() => { getAndSetSessions(); getAndSetFavoriteSessions(userId) }, [userId])

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId === userId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.categoryId - b.activity.categoryId
              });
            setSessions(filtered);
        });
    }

    const getAndSetFavoriteSessions = () => {
        getFavoritesByMusicianId(userId).then(data =>setFavoriteSessions(data));
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

            <section className="sessions-cards">

                <div id="create-session-div">
                    <img id="plus-icon" className="plus-icon" alt="plus icon" src={plusIcon}/>
                </div>

                {/* returns card for each session */}
                {sessions.map(s => {
                    return( 
                    <div className="session">
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
                                <h5>Notes</h5>
                                <p>{s.notes}</p>
                            </div>
                        </div> 

                        <div className="session-div-btns">
                            {favoriteSessions?.map(fs => {
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
                            })}

                            <img id="repeat-icon" className="repeat-icon" alt="repeat icon" src={repeatIcon}/>
                            <img id="delete-icon" className="delete-icon" alt="delete icon" src={deleteIcon}/>

                        </div>
                    </div>
                )})}

            </section>

        </section>
    )
}