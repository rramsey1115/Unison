import "./MySessions.css";
import { useNavigate } from "react-router-dom";
import plusIcon from "../../../../images/plus-icon.png";
import filledFav from "../../../../images/filled-favorite.png"
import repeatIcon from "../../../../images/start.png";
import emptyFav from "../../../../images/empty-favorite.png"
import { useEffect, useState } from "react";
import { deleteSessionById, getAllSessions, getSessionById } from "../../../../Managers/sessionManager";
import { addFavorite, getFavoritesByMusicianId, removeFavorite } from "../../../../Managers/favoriteSessionsManager";
import { ConfirmDeleteModal } from "./ConfirmDeleteModal";
import { getAllComments } from "../../../../Managers/commentManager";
import { Button } from "reactstrap";

export const MySessions = ({ loggedInUser }) => {
    const [favoriteSessions, setFavoriteSessions] = useState([]);
    const [sessions, setSessions] = useState([]);
    const [comments, setComments] = useState([]);
    const [filterFavs, setFilterFavs] = useState(false);
    const userId = loggedInUser.id;

    useEffect(() => { 
        getAndSetSessions(); 
        getAndSetFavoriteSessions(userId); 
        getAndSetComments(); 
    }, [filterFavs]);

    const getAndSetSessions = () => {
        filterFavs === false ?
        // get all sessions with matching userId & then order by activity date
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId === userId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.categoryId - b.activity.categoryId
              });
            setSessions(filtered);
        })
        :
        // get only favorite sessions
        getFavoritesByMusicianId(userId).then((data) => {
            var promises = [];
        
            if (data.length === 0) 
            {
                setSessions([]);
            } 
            else 
            {
                for (const d of data) 
                {
                    // holds results of fetch call - the session object
                    promises.push(getSessionById(d.sessionId * 1));
                }
                // once all promises in the promises array are resolved, setSessions to the result
                Promise.all(promises).then((results) => {
                    setSessions(results);
                })
            }
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

    const handleAddFav = (sesId) => {
        var obj = {
            sessionId:sesId, 
            musicianId:userId
        }
        addFavorite(obj).then(() => {
            getAndSetFavoriteSessions(userId);
        })
    };

    const handleRemoveFav = (favSessId) => {
        removeFavorite(favSessId).then(() => {
            getAndSetFavoriteSessions();
        });
    };

    return (
        <section className="sessions-container">
            <header className="sessions-header">
                <h1>{loggedInUser.firstName}'s Sessions</h1>
                <div>
                    {filterFavs===false
                    ? 
                    <Button
                        id="filter-on-btn"
                        size="md" 
                        color="info"
                        onClick={(e) => setFilterFavs(!filterFavs)}
                    >Favorites Only
                    </Button>
                    : 
                    <Button
                        id="filter-on-btn"
                        size="md"
                        color="info"
                        onClick={(e) => setFilterFavs(!filterFavs)}
                    >Show All
                    </Button>
                    }
                </div>
            </header>
            <section className="sessions-cards">
                <div id="create-session-div" onClick={(e) => navigate('create')}>
                    <img id="plus-icon" className="plus-icon" alt="plus icon" src={plusIcon}/>
                </div>
                 {/* returns a card for each session */}
                {sessions.map(s => {
                    // sets comments for this session - if null handled below
                    var arr = comments.filter(c => c.sessionId === s.id);
                    
                    // sets if this session is favorited or not & favoriteSessionId
                    let isFavorite = false;
                    let favId = 0;
                    favoriteSessions.forEach(fs => {
                        if (fs.sessionId === s.id)
                        {
                            isFavorite = true;
                            favId = fs.id;
                        }
                    })

                    return( 
                    <div key={s.id} className="session">
                        <div key={s.id} className="session-div">
                            <div className="session-div-header">
                                <h4 id="session-div-header-date">{getFormattedDate(s.dateCompleted)}</h4>
                            </div>
                            <h5>Total Time: {s.duration} Minutes</h5>
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
                            {isFavorite === true ?
                                <button
                                    key={favId}
                                    value={favId}
                                    className="session-activities-btn"
                                    onClick={(e) => handleRemoveFav(e.currentTarget.value * 1)}
                                    >
                                    <img
                                        id="favorite-icon"
                                        className="favorite-icon"
                                        alt="favorite icon"
                                        src={filledFav}
                                    />
                                </button>
                            : 
                                <button
                                    key={s.id}
                                    value={s.id}
                                    className="session-activities-btn"
                                    onClick={(e) => handleAddFav(e.currentTarget.value * 1)}
                                    >
                                        <img
                                            id="favorite-icon"
                                            className="favorite-icon"
                                            alt="favorite icon"
                                            src={emptyFav}
                                        />
                                </button>
                            }

                            <button className="session-activities-btn">
                                <img 
                                    id="repeat-icon" 
                                    className="repeat-icon" 
                                    alt="repeat icon" 
                                    src={repeatIcon}
                                />
                            </button>

                            <ConfirmDeleteModal session={s} handleDeleteSession={handleDeleteSession} getFormattedDate={getFormattedDate}/>
                            
                        </div>
                    </div>
                )})}
            </section>
        </section>
    );
}