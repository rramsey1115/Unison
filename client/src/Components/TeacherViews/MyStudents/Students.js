import { Table } from "reactstrap"
import "./Students.css";
import { useState } from "react";

export const Students = () => {
    const [students, setStudents] = useState([]);

    const getAndSetStudents = () => {
        
    }

    return (
        <div className="students-container">
            <div className="students-header">
                <h1>My Students</h1>
            </div>
            <div className="students-body">
                <Table className="table" id="student-table" hover striped color="primary">
                        <thead>
                            <tr>
                                <td>Id</td>
                                <td>Name</td>
                                <td>Email</td>
                                <td>Last Session</td>
                                <td>Stats</td>
                                <td>Assign</td>
                                <td>Remove</td>
                            </tr>
                        </thead>
                        <tbody>
                            
                        </tbody>
                </Table>
            </div>
        </div>
    )
}