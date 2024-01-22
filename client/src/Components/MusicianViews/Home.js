import { Card, CardBody, CardDeck, CardFooter, CardHeader, CardImg, CardImgOverlay, CardText, CardTitle } from "reactstrap"
import "./Home.css";
import create from "../../images/create.gif";
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
                    <h3>Past Sessions</h3>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('session/create')}>
                    <h3>New Session</h3>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('/')}>
                    <h3>Stats</h3>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('/')}>
                    <h3>Assignments</h3>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('favorite')}>
                    <h3>Favorites</h3>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('browse/category')}>
                    <h3>Browse</h3>
                </Card>
   
            </section>

        </section>
    )
}