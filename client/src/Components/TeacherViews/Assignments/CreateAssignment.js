import { useEffect, useState } from "react";
import "../../MusicianViews/Sessions/CreateSession/CreateSession.css";
import removeIcon from "../../../images/delete.png";
import { useNavigate } from "react-router-dom";
import { ScaleLoader } from "react-spinners";
import { SessionActivitySelect } from "../../MusicianViews/Sessions/CreateSession/SessionActivitySelect";
import { getTeacherStudents, getUserById } from "../../../Managers/profileManager";
import { Button, Input } from "reactstrap";
import { createNewSession } from "../../../Managers/sessionManager";
import { createNewAssignment } from "../../../Managers/assignmentManager";

export const CreateAssignment = ({ loggedInUser }) => {
    const [totalTime, setTotalTime] = useState(0);
    const [musicianId, setMusicianId] = useState(0);
    const [students, setStudents] = useState([]);
    const [student, setStudent] = useState({});
    const [newSession, setNewSession] = useState({});
    const [newAssignment, setNewAssignment] = useState({});
    const [dueDays, setDueDays] = useState(1);

    useEffect(() => { getAndSetStudents() }, [loggedInUser]);
    useEffect(() => { if (musicianId > 0) getAndSetStudentById(musicianId)}, [musicianId]);

    useEffect(() => {

        setNewSession({
            musicianId: musicianId,
            sessionActivities: []
        });

        setNewAssignment({
            musicianId: musicianId,
            teacherId: loggedInUser.id,
            dueDate: new Date(Date.now() + dueDays * 60 * 60 * 24 * 1000)
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

    const getAndSetStudentById = (musicianId) => {
        getUserById(musicianId).then(setStudent);
    }

    const navigate = useNavigate();

    const handleSubmitAssignment = async () => {    
        const copy = {
            musicianId: musicianId,
            sessionActivities: []
        }
        newSession.sessionActivities.map(sa => copy.sessionActivities.push(
            {
            activityId: sa.activityId,
            duration: sa.duration
            }
        ));
        await createNewSession(copy);
        await createNewAssignment(newAssignment);
        navigate(`/assignments/${student.id}`)
    }

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
                    <h4>Total Time: {totalTime} Minutes</h4>
                    <h4>Musician: {student.firstName} {student.lastName}</h4>
                    <h4>Due Date: {newAssignment.dueDate && new Date(newAssignment.dueDate).toLocaleDateString()}</h4> 
                    
                </header>
                    <fieldset id="session-activities" className="session-form-fieldset">
                        <label><span style={{fontSize:20}}>Choose Student</span>
                            <select 
                                className="create-session-dropdown"
                                onChange={(e) => {setMusicianId(e.target.value*1)}}
                            >
                                <option value={0}>Students</option>
                                {students.map(s => {
                                    return(
                                        <option key={s.id} value={s.id}>{s.firstName} {s.lastName}</option>
                                    )
                                })}
                            </select> 
                        </label>
                    </fieldset>
                    <fieldset id="session-number-select" className="session-form-fieldset">
                        <label><span style={{fontSize:20}}>Choose Days Unil Due</span>
                            <Input className="create-session-dropdown" type="number" min={0} defaultValue={1} onChange={(e) => setDueDays(e.target.value)}/>
                        </label>
                    </fieldset>
                
                {newSession.sessionActivities?.length >= 1 
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

                {newSession?.musicianId > 0 ?
                <fieldset className="session-form-fieldset">
                    <SessionActivitySelect setNewSession={setNewSession} newSession={newSession} loggedInUser={loggedInUser}/>
                </fieldset>
                : null}

                {newAssignment.dueDate && 
                newAssignment.teacherId && 
                newAssignment.musicianId && 
                newSession.musicianId && 
                newSession.sessionActivities?.length > 0 
                ?
                    <fieldset className="session-form-fieldset">
                        <div className="submit-btn-container">
                            <Button 
                                id="submit-assignment-btn"
                                size="md" 
                                color="info"
                                onClick={(e) => handleSubmitAssignment()}
                            >Submit
                            </Button>
                        </div>
                    </fieldset>
                : null}
            </section>
        </div>
    )
}