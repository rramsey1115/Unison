import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"
import { ScaleLoader } from "react-spinners";
import { Card, CardHeader } from "reactstrap";
// import "../../images/"

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
                    <img alt="" />
                    <h5>My Students</h5>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('browse/category')}>
                    <h5>Browse</h5>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('assignments/create')}>
                    <h5>Assign</h5>
                </Card>
   
            </section>

        </section>
    )
}