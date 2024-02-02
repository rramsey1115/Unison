import { useParams } from "react-router-dom";
import "./Profile.css";
import { useEffect, useState } from "react";
import { ScaleLoader } from "react-spinners";
import { Button } from "reactstrap";
import { getStatsByUserId } from "../../../Managers/statsManager";

export const StudentProfile = ({ loggedInUser }) => {
    const studentId = useParams().id * 1;
    const [stats, setStats] = useState({});
    const [isLoaded, setIsLoaded] = useState(false);

    useEffect(() => {
        if(studentId > 0){ getandsetStats(studentId) }

        setTimeout(() => {
            setIsLoaded(true);
        }, 1500);

    }, [studentId]);

    const getandsetStats = (id) => {
        getStatsByUserId(id).then(setStats);
    }

    function toHoursAndMinutes(totalMinutes) {
        const hours = Math.floor(totalMinutes / 60);
        const minutes = totalMinutes % 60;
        return `${hours}h${minutes > 0 ? ` ${minutes}m` : ""}`;
    }

    console.log('stats', stats);

    return (
    !stats.user?.lastName || isLoaded === false
    ?
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <div className="profile-container">
            <header className="profile-header">
                <h2>{`${stats.user.firstName} ${stats.user.lastName}`}</h2>
            </header>

            <section className="profile-body">
                <div className="profile-about">
                    <div className="profile-about-header">
                        <h5>About</h5>
                        {stats.userId === loggedInUser.id || loggedInUser.id === stats.user.teacherId
                        ? <Button size="sm" color="info">Edit Profile</Button>
                        : null}
                    </div>
                    <ul className="profile-ul">
                        <li>Email: {stats.user.email}</li>
                        <li>UserName: {stats.user.userName}</li>
                        {loggedInUser.id === stats.user.teacherId && <li>Address: {stats.user.address}</li>}
                        {stats.user.teacher ? <li>Teacher: {`${stats.user.teacher.firstName} ${stats.user.teacher.lastName}`}</li> : null}
                    </ul>
                </div>
                {/* visible if looking at a teacher's profile */}
                {stats.user.roles && stats.user.roles[0] != "Musician"
                ?<div className="profile-teacher-div">
                    <h5>Teacher Stats</h5>
                        <ul>
                            <li>Total Students</li>
                            <li>???</li>
                        </ul>
                </div>
                // visible if viewing a student's profile
                :<div className="profile-stats">
                    <h5>Practice Stats</h5>
                    <ul>
                        <li>Total Practice Sessions: {stats.completedSessions}</li>
                        <li>Total Assignments Completed: {stats.completedAssignments}</li>
                        <li>Total Time Spent Practicing: {toHoursAndMinutes(stats.totalTime)} Minutes</li>
                        <li>Most Recent Session: {new Date(stats.lastSession).toLocaleDateString()}</li>
                        <li>Most Frequent Category: {stats.topCategory.name}</li>
                        <li>Most Frequent Activity: {stats.topActivity.name}</li>
                    </ul>
                    <h5>Graph??</h5>
                </div>}
            </section>

        </div>
    )
}