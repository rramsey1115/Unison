import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { ScaleLoader } from "react-spinners";
import { getUserById } from "../../../Managers/profileManager";
import "./AssignmentsStyles.css";

export const Assignments = ({ loggedInUser }) => {
    const studentId = useParams().id * 1;
    const [student, setStudent] = useState({});

    useEffect(() => {
        if (studentId) { getAndSetStudentById(studentId)}
    }, [studentId]);

    const getAndSetStudentById = (studentId) => {
        getUserById(studentId).then(setStudent);
    }

    return (
    !student
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
                <h5>Assignments List</h5>
            </section>
        </div>
    );
}