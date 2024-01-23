import { useNavigate, useParams } from "react-router-dom";
import "./ActiveSession.css";
import { completeSession, getSessionById } from "../../../../Managers/sessionManager";
import { useEffect, useState } from "react";
import { Button } from "reactstrap";

export const ActiveSession = ({loggedInUser}) => {
    const sessionId = useParams().id;
    const [session, setSession] = useState({});
    const [updated, setUpdated] = useState({});

    useEffect(() => { if(sessionId){getAndSetSessionById(sessionId)} }, [sessionId])

    useEffect(() => { setUpdated({...session}) }, [session]);

    const getAndSetSessionById = (sessionId) => {
        getSessionById(sessionId).then(setSession);
    }

    const navigate = useNavigate();

    const handleComplete = async (e) => {
        e.preventDefault();
        console.log('updated', updated);
        await completeSession(updated);
        navigate('/session');
    }

    console.log('session',session);

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
                            value={updated.notes}
                            onChange={(e) => {
                                const copy = {...updated};
                                copy.notes = e.target.value;
                                setUpdated(copy);
                            }}
                        />
                    </div>

                    <div className="active-btn-container">
                        <Button 
                            id="active-btn-complete" 
                            className="active-btn" 
                            onClick={(e) => handleComplete(e)}
                        >
                            Complete
                        </Button>
                        <Button 
                            id="active-btn-exit" 
                            className="active-btn"
                            
                        >
                            Exit
                        </Button>
                    </div>
                </section>

            </section>

        </div>
    )
}