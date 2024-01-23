import { useParams } from "react-router-dom";
import "./ActiveSession.css";
import { getSessionById } from "../../../../Managers/sessionManager";
import { useEffect, useState } from "react";

export const ActiveSession = ({loggedInUser}) => {
    const sessionId = useParams().id;
    const [session, setSession] = useState({});

    useEffect(() => { if(sessionId){getAndSetSessionById(sessionId)} }, [sessionId])

    const getAndSetSessionById = (sessionId) => {
        getSessionById(sessionId).then(setSession);
    }

    console.log(session);

    return (
        <div className="active-container">

            <section className="active-container-form">

                <header className="active-container-header">
                    <h1>Active Session</h1>
                    <h3>Musician: {session.musician?.firstName} {session.musician?.lastName}</h3>
                </header>

                <section className="active-body">
                    <div className="active-activities-div">
                        {session.sessionActivities?.map(sa => {
                            return (
                            <div key={sa.id} className="active-activity">
                                <h4>{sa.activity.category.name}</h4>
                                <p>{sa.activity.name}</p>
                                <p>{sa.duration} minutes</p>
                            </div>)
                        })}
                    </div>
                    <div className="active-notes">
                        <textarea 
                            id="active-notes-textarea"
                            className="text-input"
                            type="text"
                            placeholder="Session Notes"

                        />
                    </div>
                </section>

            </section>

        </div>
    )
}