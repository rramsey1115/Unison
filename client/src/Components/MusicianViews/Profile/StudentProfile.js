import { useParams } from "react-router-dom";
import "./Profile.css";
import { useEffect, useState } from "react";
import { getUserById } from "../../../Managers/profileManager";
import { ScaleLoader } from "react-spinners";

export const StudentProfile = ({ loggedInUser }) => {
    const studentId = useParams().id * 1;
    const [student, setStudent] = useState({});

    useEffect(() => {
        getAndSetStudentById(studentId)
    }, [studentId])

    const getAndSetStudentById = (id) => {
        getUserById(id).then(setStudent);
    }

    return(
    !student.firstName
    ?
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <div className="profile-container">

            <header className="profile-header">
                <h2>{`${student.firstName} ${student.lastName}`}</h2>
            </header>

            <section className="profile-body">
                <div className="profile-about">
                    <h5>About</h5>
                    <ul>
                        <li>Email</li>
                        <li>Username</li>
                        <li>Teacher:(if any)</li>
                        <li>Edit Profile Btn - if matching userId or if their teacher</li>
                    </ul>
                </div>
                {student.roles && student.roles[0] == "Teacher"
                ?<div className="profile-teacher-div">
                    <h5>Teacher Stats</h5>
                        <ul>
                            <li>Total Students</li>
                            <li>???</li>
                        </ul>
                </div>
                :<div className="profile-stats">
                    <h5>Profile Stats</h5>
                    <ul>
                        <li>Total Practice Sessions</li>
                        <li>Total Time Spent Practicing</li>
                        <li>Most Recent Session</li>
                        <li>Most Frequent Category</li>
                        <li>Most Frequent Activity</li>
                        <li>Total Assignments Completed</li>
                        <li>Last Session</li>
                        <li>Last Session</li>
                    </ul>
                </div>}
            </section>

        </div>
    )
}