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
    !student
    ?
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <div className="profile-container">

            <header className="profile-header">
                <h2>{`${student.firstName} ${student.lastName}'s Profile`}</h2>
            </header>

            <section className="profile-body">
                <div className="profile-about">
                    <h5>About</h5>
                </div>
                {loggedInUser.roles[0]==="Teacher"
                ?<div className="profile-teacher-div">

                </div>
                :<div className="profile-stats">
                    <h5>Profile Stats</h5>
                </div>}
            </section>

        </div>
    )
}