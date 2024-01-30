import { useEffect, useState } from "react";
import "../../MusicianViews/Sessions/CreateSession/CreateSession.css";
import removeIcon from "../../../images/delete.png";
import { useNavigate } from "react-router-dom";
import { ScaleLoader } from "react-spinners";
import { SessionActivitySelect } from "../../MusicianViews/Sessions/CreateSession/SessionActivitySelect";
import { getTeacherStudents } from "../../../Managers/profileManager";

export const CreateAssignment = ({ loggedInUser }) => {
    const [totalTime, setTotalTime] = useState(0);
    const [musicianId, setMusicianId] = useState(0);
    const [students, setStudents] = useState([]);
    const [newSession, setNewSession] = useState({});
    const [newAssignment, setNewAssignment] = useState({});
    const [dueDays, setDuteDays] = useState(0);

    useEffect(() => { getAndSetStudents() }, [loggedInUser]);

    useEffect(() => {

        setNewSession({
            musicianId: musicianId,
            sessionActivities: []
        });

        setNewAssignment({
            musicianId: musicianId,
            teacherId: loggedInUser.id,
            dueDate: Date.now() + dueDays * 7 * 60 * 60 * 24 * 1000
        });

    }, [loggedInUser, musicianId, dueDays]);

    useEffect(() => {
        var total = 0;
        newSession.sessionActivities?.map(sa => total += sa.duration )
        setTotalTime(total);
    }, [newSession]);

    const handleRemoveActivity = (id) => {
        const copy = {...newSession};
        var arr = newSession.sessionActivities.filter( a => a.activityId !== id);
        copy.sessionActivities = arr;
        setNewSession(copy);
    };

    const getAndSetStudents = () => {
        getTeacherStudents(loggedInUser.id).then(setStudents);
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
                <h1>Create Assignment</h1>
            </header>
            <section className="create-session-form">
                <header className="session-form-header">
                    <h3>Total Time: {totalTime} Minutes</h3>
                </header>
                {newSession.musicianId === 0 ?
                    <select>
                        <option value={0}>Students</option>
                    </select> 
                : null}
                
                {newSession.sessionActivities?.length > 0 
                ? newSession.sessionActivities.map(sa => {
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
                            </div>
                        </fieldset>
                    )})
                : null}

                {newSession.musicianId > 0 ??
                <fieldset id="activity-fieldset" className="session-form-fieldset">
                    <SessionActivitySelect setNewSession={setNewSession} newSession={newSession} loggedInUser={loggedInUser}/>
                </fieldset>}

            </section>
        </div>
    )
}