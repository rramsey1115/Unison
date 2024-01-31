import { Card } from "reactstrap"
import "./Home.css";
import { useNavigate } from "react-router-dom";
import { ScaleLoader } from "react-spinners";
import { useEffect, useState } from "react";

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

                <Card className="home-card" onClick={(e) => navigate('/')}>
                    <h4>Stats</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate(`/assignments/${loggedInUser.id}`)}>
                    <h4>Assignments</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('browse/category')}>
                    <h4>Browse</h4>
                </Card>
   
            </section>

        </section>
    )
}