import { Card } from "reactstrap"
import "./Home.css";
import { useNavigate } from "react-router-dom";
import { ScaleLoader } from "react-spinners";
import { useEffect, useState } from "react";
import assignIcon from "../../images/assign.png";
import browseIcon from "../../images/browse.png";

export const Home = ({loggedInUser}) => {
    const navigate = useNavigate();
    const [loaded, setLoaded] = useState(false);

    useEffect(() => {
        setTimeout(() => {
            setLoaded(true);
        }, 1000);
    }, []); // empty dependency to only run once
    
    return (
        loaded===false
        ?
            <div className="spinner-container">
                <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
            </div>
        :
        <section className="home-container">

            <header className="home-header">
                <h1>Home</h1>
            </header>
            
            <section className="home-main">

                <Card className="home-card" onClick={(e) => navigate('session')}>
                    <h4>Sessions</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('session/create')}>
                    <h4>New Session</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate(`/profile/${loggedInUser.id}`)}>
                    <h4>My Profile</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate(`/assignments/${loggedInUser.id}`)}>
                    <img className="card-img" src={assignIcon} alt="paper with items and checkmarks"/>
                    <h4>Assignments</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('browse/category')}>
                    <img className="card-img" src={browseIcon} alt="microscope over browser"/>
                    <h4>Browse</h4>
                </Card>
   
            </section>

        </section>
    )
}