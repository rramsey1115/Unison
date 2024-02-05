import { Button, Table } from "reactstrap"
import "./Students.css";
import { useEffect, useState } from "react";
import { getTeacherStudents } from "../../../Managers/profileManager";
import { LastSession } from "./LastSession";
import { useNavigate } from "react-router-dom";
import { ScaleLoader } from "react-spinners";

export const Students = ({loggedInUser}) => {
    const [students, setStudents] = useState([]);

    useEffect(() => { getAndSetStudents() }, [loggedInUser]);

    const getAndSetStudents = () => {
        getTeacherStudents(loggedInUser.id).then(setStudents);
    }

    const navigate = useNavigate();

    return (
        !students
        ? 
            <div className="spinner-container">
                <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
            </div>
        :
        <div className="students-container">
            <div className="students-header">
                <h2>My Students</h2>
            </div>
            <div className="students-body">
                <Table className="student-table" id="student-table" responsive>
                        <thead>
                            <tr className="table-secondary">
                                <th>Name</th>
                                {/* <th>Email</th> */}
                                <th>Last Session</th>
                                <th>Sessions</th>
                                <th>Stats</th>
                                <th>Assignment</th>
                                <th>Remove</th>
                            </tr>
                        </thead>
                        <tbody>
                            {students.map(s => {
                                return(
                                    <tr key={s.id} style={{padding:20}}>
                                        <td>{`${s.firstName} ${s.lastName}`}</td>
                                        {/* <td>{s.email}</td> */}
                                        <td><LastSession studentId={s.id}/></td>
                                        <td>
                                            <Button 
                                                color="info" 
                                                size="sm" 
                                                className="student-table-btn"
                                                value={s.id}
                                                onClick={(e) => {navigate(`sessions/${e.target.value}`)}}
                                            >Sessions
                                            </Button>
                                        </td>
                                        <td>
                                            <Button 
                                                color="info" 
                                                size="sm" 
                                                className="student-table-btn"
                                                value={s.id}
                                                onClick={(e) => {navigate(`/profile/${e.target.value}`)}}
                                            >Stats
                                            </Button>
                                        </td>
                                        <td>
                                            <Button 
                                                color="info" 
                                                size="sm" 
                                                className="student-table-btn"
                                                value={s.id}
                                                onClick={(e) => navigate(`/assignments/${e.target.value*1}`)}
                                            >Assignments
                                            </Button>
                                        </td>
                                        <td>
                                            <Button 
                                                color="secondary" 
                                                size="sm" 
                                                className="student-table-btn"
                                            >Remove
                                            </Button>
                                        </td>
                                    </tr>
                                )
                            })}
                        </tbody>
                </Table>
            </div>
        </div>
    )
}