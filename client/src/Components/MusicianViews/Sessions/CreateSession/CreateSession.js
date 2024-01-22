import { useEffect, useState } from "react";
import "./CreateSession.css";
import startIcon from "../../../../images/start.png";
import { SessionActivitySelect } from "./SessionActivitySelect";
import { getActivityById } from "../../../../Managers/activityManager";

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
                ?newSession.sessionActivities?.map(sa => {
                        return (
                            <fieldset key={sa.id} className="sessionActivities">
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

                <fieldset id="button-fieldset" className="session-form-fieldset">
                    <img id="session-start-btn" alt="start" src={startIcon}/>
                </fieldset>

            </section>

        </div>
    )
}