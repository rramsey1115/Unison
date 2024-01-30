import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { ScaleLoader } from "react-spinners";
import { getUserById } from "../../../Managers/profileManager";
import "./AssignmentsStyles.css";
import "../Sessions/MySessions/MySessions.css";
import { getAssignmentByMusicianId } from "../../../Managers/assignmentManager";
import { getAllComments } from "../../../Managers/commentManager";

export const Assignments = ({ loggedInUser }) => {
    const studentId = useParams().id * 1;
    const [student, setStudent] = useState({});
    const [comments, setComments] = useState([]);
    const [assignments, setAssignments] = useState([]);

    useEffect(() => {
        if (studentId) { 
            getAndSetStudentById(studentId);
            getAndSetActivities(studentId);
            getAndSetComments();
        }
    }, [studentId]);

    const getAndSetComments = () => { getAllComments().then(setComments)};
    const getAndSetActivities = (studentId) => {getAssignmentByMusicianId(studentId).then(setAssignments)}
    const getAndSetStudentById = (studentId) => { getUserById(studentId).then(setStudent);}

    return (
    !student || !assignments || !comments
    ? 
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
    <div className="assignments-container">
            <header className="assignments-header">
                <h1>{`${student.firstName} ${student.lastName}'s Assignments`}</h1>
            </header>
            <section className="assignments-body">
                {assignments.map(a => {
                    console.log(a);
                    var arr = comments.filter(c => c.sessionId === a.session.id);

                    return(
                    <div key={a.session.id} className="session">
                        <div key={a.session.id} className="session-div">
                            <div className="session-div-header">
                                {a.complete 
                                ?<h4 style={{color:"green"}}>Completed: {new Date(a.session.dateCompleted).toLocaleDateString()}</h4>
                                : <h4 style={{color:"red"}}>Due: {new Date(a.dueDate).toLocaleDateString()} </h4> }
                            </div>
                            <h5>Total Time: {a.session.duration} Minutes</h5>
                            {a.session.sessionActivities.map(sa => {
                                return (
                                <div id="session-div-activities" className="session-card" key={sa.id}>
                                    <h5 >{sa.activity.category.name}</h5>
                                    <p>{sa.activity.name}</p>
                                </div>)}
                            )}
                        
                            <div className="session-div-notes">
                                <h5>My Notes</h5>
                                <p>{a.session.notes}</p>
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
                    </div>)}
                )} 
            </section>
        </div>
    );
}