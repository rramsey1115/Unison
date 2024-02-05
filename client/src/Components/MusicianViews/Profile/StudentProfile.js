import { useParams } from "react-router-dom";
import "./Profile.css";
import { useEffect, useState } from "react";
import { ScaleLoader } from "react-spinners";
import { getStatsByUserId } from "../../../Managers/statsManager";
import { EditProfileModal } from "./EditProfileModal";
import { getUserById } from "../../../Managers/profileManager";
import { HeatMap } from "./HeatMap";

export const StudentProfile = ({ loggedInUser }) => {
    const studentId = useParams().id * 1;
    const [stats, setStats] = useState({});
    const [user, setUser] = useState({});
    const [isLoaded, setIsLoaded] = useState(false);
    const [dates, setDates] = useState([]);

    useEffect(() => {
        if(studentId > 0)
        { 
            getAndSetUser(studentId);
            getandsetStats(studentId); 
        }

        setTimeout(() => {
            setIsLoaded(true);
        }, 1500);
    }, [studentId]);

    useEffect(() => {getAndSetDates()}, [stats]);

    const getandsetStats = (id) => {
        getStatsByUserId(id).then(setStats);
    }

    const getAndSetDates = () => {
        var arr = [];
        if(stats.userSessions?.length > 0)
        {
            stats.userSessions.map(s => {
                if(s.dateCompleted !== null)
                {
                    arr.push(s.dateCompleted)
                }
            });
            setDates(arr);
        }
    }

    const getAndSetUser = (id) => {
        getUserById(id).then(setUser);
    }

    function toHoursAndMinutes(totalMinutes) {
        const hours = Math.floor(totalMinutes / 60);
        const minutes = totalMinutes % 60;
        return `${hours}h${minutes > 0 ? ` ${minutes}m` : ""}`;
    }

   


    return (
    !stats.user?.lastName || isLoaded === false || !user.firstName
    ?
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <div className="profile-container">
            <header className="profile-header">
                <h2>{`${user.firstName} ${user.lastName}`}</h2>
            </header>

            <section className="profile-body">
                <div className="profile-div">
                    <div className="profile-div-header">
                        <h4>About</h4>
                        {user.id === loggedInUser.id || loggedInUser.id === user.teacherId
                        ? <EditProfileModal loggedInUser={loggedInUser} user={user} getAndSetUser={getAndSetUser}/>
                        : null}
                    </div>
                    <table className="about-table">
                        <tbody>
                            <tr>
                                <th>Email</th>
                                <td>{user.email}</td>
                            </tr>
                            <tr>
                                <th>Username</th>
                                <td>{user.userName}</td>
                            </tr>
                            {loggedInUser.id === user.teacherId &&
                            <tr>
                                <th>Address</th>
                                <td>{user.address}</td>
                            </tr>}
                            {user.teacher &&
                            <tr>
                                <th>Teacher</th>
                                <td>{user.teacher.firstName} {user.teacher.lastName}</td>
                            </tr>}

                        </tbody>
                    </table>
                </div>
                {/* visible if looking at a teacher's profile */}
                {user.roles && user.roles[0] !== "Musician"
                ?<div className="profile-teacher-div">
                    <h4>Teacher Stats</h4>
                        <ul>
                            <li>Total Students</li>
                            <li>???</li>
                        </ul>
                </div>
                // visible if viewing a student's profile
                :<div className="profile-div">
                    <h4>Practice Stats</h4>
                    <table className="about-table">
                        <tbody>
                            <tr>
                                <th>Completed Sessions</th>
                                <td>{stats.completedSessions}</td>
                            </tr>
                            <tr>
                                <th>Completed Assignments</th>
                                <td>{stats.completedAssignments}</td>
                            </tr>
                            <tr>
                                <th>Incomplete Assignments</th>
                                <td>{stats.incompleteAssignments}</td>
                            </tr>
                            <tr>
                                <th>Overdue Assignments</th>
                                <td>{stats.overdueAssignments}</td>
                            </tr>
                            <tr>
                                <th>Total Time</th>
                                <td>{toHoursAndMinutes(stats.totalTime)} Minutes</td>
                            </tr>
                            <tr>
                                <th>Most Recent</th>
                                <td>{new Date(stats.lastSession).toLocaleDateString()}</td>
                            </tr>
                            <tr>
                                <th>Top Category</th>
                                <td>{stats.topCategory.name}</td>
                            </tr>
                            <tr>
                                <th>Top Activity</th>
                                <td>{stats.topActivity.name}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>}
                <div className="profile-div">
                    <h4>Practice Sessions</h4>
                    <HeatMap dates={dates}/>
                </div>
            </section>
        </div>
    )
}