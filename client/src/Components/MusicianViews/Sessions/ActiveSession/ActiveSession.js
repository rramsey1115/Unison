import { useNavigate, useParams } from "react-router-dom";
import "./ActiveSession.css";
import { completeSession, getSessionById } from "../../../../Managers/sessionManager";
import { useEffect, useState } from "react";
import { Button } from "reactstrap";
import { ScaleLoader } from "react-spinners";
import { CountdownTimer } from "./CountdownTimer";


export const ActiveSession = ({loggedInUser}) => {
    const sessionId = useParams().id;
    const [session, setSession] = useState({});
    const [updated, setUpdated] = useState({});
    const activityDurationsArr = [];

    useEffect(() => { if(sessionId){getAndSetSessionById(sessionId)} }, [sessionId])

    useEffect(() => { setUpdated({...session}) }, [session]);

    const getAndSetSessionById = (sessionId) => {
        getSessionById(sessionId).then(setSession);
    }

    const navigate = useNavigate();

    const handleComplete = async (e) => {
        e.preventDefault();
        await completeSession(updated);
        navigate('/session');
    }

    return (
        !session.sessionActivities || loggedInUser.id !== session.musicianId || session.dateCompleted!==null
        ? 
            <div className="spinner-container">
                
                <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
                {loggedInUser.id !== session.musicianId && 
                <h5 style={{margin:"20px auto", textAlign:"center"}}>Cannot complete sessions that you did not create</h5>}
                {session.dateCompleted!==null && 
                <h5 style={{margin:"20px auto", textAlign:"center"}}>This session has already been completed. You may replay it from your session view.</h5>}
            </div>
        :
        <div className="active-container">

            <section className="active-container-form">
                <header className="active-container-header">
                    <h1>Active Session</h1>
                    <h3>Musician: {session.musician?.firstName} {session.musician?.lastName}</h3>
                </header>

                <section className="active-body">
                    <div className="active-activities-div">
                        {session.sessionActivities?.map(sa => {
                            activityDurationsArr.push(sa);
                            return (
                            <div key={sa.id} className="active-activity">
                                <h4>{sa.activity.category.name}</h4>
                                <p>{sa.activity.name}</p>
                                <p>{sa.duration} minutes</p>
                            </div>)
                        })}
                    </div>
                    {console.log('activityDurationsArr', activityDurationsArr)}
                    <div className="active-notes">
                        <textarea 
                            id="active-notes-textarea"
                            className="text-input"
                            type="text"
                            placeholder="Session Notes"
                            onChange={(e) => {
                                const copy = {...updated};
                                copy.notes = e.target.value;
                                setUpdated(copy);
                            }}
                        />
                    </div>

                    <div className="timer-div">
                        <CountdownTimer arr={activityDurationsArr}/>
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
                            onClick={(e) => navigate('/session')}
                        >
                            Exit
                        </Button>
                    </div>
                </section>

            </section>

        </div>
    )
}