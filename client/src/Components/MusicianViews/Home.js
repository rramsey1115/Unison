import { Card } from "reactstrap"
import "./Home.css";
import { useNavigate } from "react-router-dom";

export const Home = () => {
    const navigate = useNavigate();

    return (
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

                <Card className="home-card" onClick={(e) => navigate('/')}>
                    <h4>Assignments</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('favorite')}>
                    <h4>Favorites</h4>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('browse/category')}>
                    <h4>Browse</h4>
                </Card>
   
            </section>

        </section>
    )
}