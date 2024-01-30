import { useEffect, useState } from "react";
import "./CreateSession.css";
import startIcon from "../../../../images/start.png";
import removeIcon from "../../../../images/delete.png";
import { SessionActivitySelect } from "./SessionActivitySelect";
import { createNewSession } from "../../../../Managers/sessionManager";
import { useNavigate } from "react-router-dom";
import { ScaleLoader } from "react-spinners";

export const CreateSession = ({loggedInUser}) => {
    const [totalTime, setTotalTime] = useState(0);
    const [newSession, setNewSession] = useState({});

    useEffect(() => {
        if(loggedInUser.id)
        {
            setNewSession({
                musicianId: loggedInUser.id,
                sessionActivities: []
            })
        }
    }, [loggedInUser]);

    useEffect(() => {
        var total = 0;
        newSession.sessionActivities?.map(sa => total += sa.duration )
        setTotalTime(total);
    }, [newSession]);

    const handleStartSession = (e) => {
        const copy = {
            musicianId: loggedInUser.id,
            sessionActivities: []
        }
        newSession.sessionActivities.map(sa => copy.sessionActivities.push(
            {
            activityId: sa.activityId,
            duration: sa.duration
            }
        ))
        createNewSession(copy).then((data) => navigate(`/session/${data.id}`))
    }

    const handleRemoveActivity = (id) => {
        const copy = {...newSession};
        var arr = newSession.sessionActivities.filter( a => a.activityId !== id);
        copy.sessionActivities = arr;
        setNewSession(copy);
    }

    const navigate = useNavigate();

    return (
        !newSession
        ? 
            <div className="spinner-container">
                <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
            </div>
        :
        <div className="create-session-container">

            <header className="create-session-header">
                <h1>Create Session</h1>
            </header>

            <section className="create-session-form">

                <header className="session-form-header">
                    <h3>Total Time: {totalTime} Minutes</h3>
                </header>
                
                {newSession.sessionActivities?.length > 0 
                ?newSession.sessionActivities.map(sa => {
                        return (
                            <fieldset key={sa.activityId} id="session-activities" className="session-form-fieldset">
                                <div className="session-activities-info"> 
                                    <h3>{sa.activity.category?.name}</h3>
                                    <h5>{sa.activity.name}</h5>
                                    <h5>{sa.duration} minutes</h5>
                                </div>
                                <div id="session-activities-btns">
                                    <button
                                        className="session-activities-btn"
                                        value={sa.activityId}
                                        onClick={(e) => handleRemoveActivity(e.currentTarget.value * 1)}
                                    >
                                        <img 
                                            id="remove-activity-icon" 
                                            className="remove-icon" 
                                            src={removeIcon} 
                                            alt="remove icon" 
                                        />
                                    </button>

                                    {/* <button
                                        className="session-activities-btn"
                                        value={sa.activityId}
                                    >
                                        <img 
                                            id="edit-activity-icon" 
                                            className="edit-icon" 
                                            src={editIcon} 
                                            alt="edit icon" 
                                        />
                                    </button> */}

                                </div>
                            </fieldset>
                        )
                    })
                :null
                }

                <fieldset id="activity-fieldset" className="session-form-fieldset">
                    <SessionActivitySelect setNewSession={setNewSession} newSession={newSession} loggedInUser={loggedInUser}/>
                </fieldset>


                {newSession.musicianId &&
                newSession.sessionActivities.length > 0 
                ? <fieldset id="button-fieldset" className="session-form-fieldset">
                    <img 
                        id="session-start-btn" 
                        alt="start" 
                        src={startIcon}
                        onClick={(e) => handleStartSession(e)}/>
                </fieldset>
                : null}

            </section>

        </div>
    )
}