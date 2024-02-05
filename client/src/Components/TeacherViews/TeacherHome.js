import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"
import { ScaleLoader } from "react-spinners";
import { Card } from "reactstrap";
import browseIcon from "../../images/browse.png";
import studentsIcon from "../../images/students.png";
import assignIcon from "../../images/assign.png";

export const TeacherHome = () => {

    const navigate = useNavigate();

    const [loaded, setLoaded] = useState(false);

    useEffect(() => {
        setTimeout(() => {
            setLoaded(true);
        }, 1000);
    }, []); // empty dependency to only run once

    return (
        loaded === false
        ?
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
        :
        <section className="home-container">

            <header className="home-header">
                <h2>Teacher Dashboard</h2>
            </header>
            
            <section className="home-main">

                <Card className="home-card" onClick={(e) => navigate('students')}>
                    <img className="card-img" src={studentsIcon} alt="user outlines"/>
                    <h5>My Students</h5>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('browse/category')}>
                    <img className="card-img" src={browseIcon} alt="microscope over browser"/>
                    <h5>Browse</h5>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('assignments/create')}>
                    <img className="card-img" src={assignIcon} alt="paper with items and checkmarks"/>
                    <h5>Assign</h5>
                </Card>
   
            </section>

        </section>
    )
}