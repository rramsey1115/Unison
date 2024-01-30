import "../../../Components/MusicianViews/Sessions/MySessions/MySessions.css";
import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { getAllSessions } from "../../../Managers/sessionManager";
import { deleteComment, getAllComments } from "../../../Managers/commentManager";
import { getUserById } from "../../../Managers/profileManager";
import { Button } from "reactstrap";
import { CommentModal } from "./CommentModal";
import { ScaleLoader } from "react-spinners";

export const StudentSessions = ({ loggedInUser }) => {
    const [sessions, setSessions] = useState([]);
    const [comments, setComments] = useState([]);
    const [student, setStudent] = useState({});
    const studentId = useParams().id*1;
    const userId = loggedInUser.id*1;

    useEffect(() => { getAndSetSessions(); getAndSetComments(); }, [studentId]);
    useEffect(() => { if(studentId)getAndSetStudentById(studentId)}, [studentId]);

    const getAndSetSessions = () => {
        getAllSessions().then((data) => {
            var filtered = data.filter(d => d.musicianId === studentId && d.dateCompleted !== null);
            filtered ?? filtered.sessionActivities.sort(function(a, b) { 
                return a.activity.categoryId - b.activity.categoryId
              });
            setSessions(filtered);
        });
    };

    const getAndSetStudentById = (studentId) => {
        getUserById(studentId).then(setStudent)
    }

    const getAndSetComments = () => {
        getAllComments().then(setComments);
    };

    const getFormattedDate = (dateString) => {
        const date = new Date(dateString); // {object Date}
        const yyyy = date.getFullYear();
        let mm = date.getMonth() + 1;
        let dd = date.getDate();
        if (dd < 10) dd = "0" + dd;
        if (mm < 10) mm = "0" + mm;
        const formatted = mm + "/" + dd + "/" + yyyy;
        return formatted;
    };

    const handleDelete = async (e) => {
        e.preventDefault();
        await deleteComment(e.target.value);
        getAndSetComments();
        getAndSetSessions();
    }

    return (
    !student.firstName || !sessions || !comments
    ? 
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <section className="sessions-container">
            <header className="sessions-header">
                <h1>{student.firstName}'s Sessions</h1>
            </header>
            <section className="sessions-cards">
                {/* returns card for each session */}
                {sessions.map(s => {
                    // sets comments for this session - if null handled below
                    var arr = comments.filter(c => c.sessionId === s.id);
                    return( 
                    <div key={s.id} className="session">
                        <div key={s.id} className="session-div">
                            <div className="session-div-header">
                                <h4 id="session-div-header-date">{getFormattedDate(s.dateCompleted)}</h4>
                            </div>
                            <h5>{s.duration} Minutes</h5>
                            {s.sessionActivities.map(a => {
                                return (
                                <div key={a.id} id="session-div-activities" className="session-card">
                                    <h5 >{a.activity.category.name}</h5>
                                    <p>{a.activity.name}</p>
                                </div>)}
                            )}
                            <div className="session-div-notes">
                                <h5>My Notes</h5>
                                <p>{s.notes}</p>
                            </div>
                            <div className="session-div-comments">
                                <h5>Teacher Comments</h5>
                                {arr.length > 0 
                                ? arr.map(a => {
                                    return (
                                        <p key={a.id}>
                                            From: {a.teacher.lastName}
                                            {(userId*1) === (a.teacherId*1) &&
                                            <Button
                                                className="delete-comment-btn"
                                                color="secondary"
                                                size="sm"
                                                value={a.id}
                                                onClick={(e) => handleDelete(e)}
                                            >Delete
                                            </Button>}
                                        <br/>{a.body}</p>
                                    )})
                                : <p>None at this time</p>}
                            </div>
                        </div>
                        <div className="session-div-btns">
                            <CommentModal 
                                getAndSetSessions={getAndSetSessions} 
                                getAndSetComments={getAndSetComments} 
                                session={s} student={student} 
                                teacherId={userId}
                            />                 
                        </div>
                    </div>
                )})}
            </section>
        </section>
    );
}