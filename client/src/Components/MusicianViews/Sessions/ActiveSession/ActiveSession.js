import { useNavigate, useParams } from "react-router-dom";
import "./ActiveSession.css";
import { completeSession, getSessionById } from "../../../../Managers/sessionManager";
import { useEffect, useState } from "react";
import { Button, Progress } from "reactstrap";
import { ScaleLoader } from "react-spinners";

export const ActiveSession = ({loggedInUser}) => {
    const sessionId = useParams().id;
    const [session, setSession] = useState({});
    const [updated, setUpdated] = useState({});
    const [isSessionCompleted, setIsSessionCompleted] = useState(false);
    const [totalRemainingTime, setTotalRemainingTime] = useState(session.totalDuration * 60 || 0);

    const [activityTimers, setActivityTimers] = useState({}); // State to store timers for each activity
    
    const activityDurationsArr = [];

    useEffect(() => { if(sessionId){getAndSetSessionById(sessionId)} }, [sessionId])

    useEffect(() => { setUpdated({...session}) }, [session]);

    useEffect(() => {
        const timers = {};
        session.sessionActivities?.forEach((sa) => {
            timers[sa.id] = startTimer(sa.id, sa.duration);
        });
    
        return () => {
            // Cleanup timers on component unmount
            Object.values(timers).forEach((timer) => clearInterval(timer));
        };
    }, [session.sessionActivities]);

    useEffect(() => {
        if (activityTimers && Object.keys(activityTimers).length > 0) {
            const totalRemainingTime = Object.values(activityTimers).reduce((acc, val) => acc + val, 0);
            setTotalRemainingTime(totalRemainingTime);
            setIsSessionCompleted(totalRemainingTime <= 0);
        }
    }, [activityTimers]);
    
    const getAndSetSessionById = (sessionId) => {
        getSessionById(sessionId).then(setSession);
    }

    const navigate = useNavigate();

    const handleComplete = async (e) => {
        e.preventDefault();
        await completeSession(updated);
        navigate('/session');
    }

    const startTimer = (activityId, duration) => {
        setActivityTimers((prevTimers) => ({
            ...prevTimers,
            [activityId]: duration * 60, // Convert duration to seconds
        }));
    
        const timer = setInterval(() => {
            setActivityTimers((prevTimers) => {
                const updatedTimers = {
                    ...prevTimers,
                    [activityId]: Math.max(0, prevTimers[activityId] - 0.25), // Ensure the timer doesn't go below 0
                };
    
                if (updatedTimers[activityId] <= 0) {
                    clearInterval(timer); // Clear the interval when the timer reaches 0
                    setIsSessionCompleted(true);
                }
    
                return updatedTimers;
            });
        }, 250); // Update the timer every quarter second to appear smooth
    
        return timer;
    };



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
                    <h2>Active Session</h2>
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
                        <h5>Session Completion</h5>
                        <Progress animated color="info" value={(totalRemainingTime / (session.duration * 60)) * 100} />
                    </div>

                    <div className="active-btn-container">
                        <Button 
                            id="active-btn-complete" 
                            className="active-btn" 
                            onClick={(e) => handleComplete(e)}
                            disabled={!isSessionCompleted}  // Disable the button if the session is not completed
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