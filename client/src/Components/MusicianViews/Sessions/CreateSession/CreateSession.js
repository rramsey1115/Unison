import { useEffect, useState } from "react";
import "./CreateSession.css";
import startIcon from "../../../../images/start.png";
import { SessionActivitySelect } from "./SessionActivitySelect";
import { createNewSession } from "../../../../Managers/sessionManager";
import { useNavigate } from "react-router-dom";

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
    }, [loggedInUser])

    useEffect(() => {
        var total = 0;
        newSession.sessionActivities?.map(sa => total += sa.duration )
        setTotalTime(total);
    }, [newSession])

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
        console.log(copy);
        createNewSession(copy).then((data) => navigate(`/session/${data.id}`))
    }
    const navigate = useNavigate();

    return (
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
                            <fieldset key={sa.activityId} className="sessionActivities">
                                <h4>{sa.activity.category?.name}</h4>
                                <h4>{sa.activity.name}</h4>
                                <h4>{sa.duration} minutes</h4>
                            </fieldset>
                        )
                    })
                :null
                }

                <fieldset id="activity-fieldset" className="session-form-fieldset">
                    <SessionActivitySelect setNewSession={setNewSession} newSession={newSession}/>
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