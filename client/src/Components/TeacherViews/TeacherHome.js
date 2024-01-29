import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"
import { ScaleLoader } from "react-spinners";
import { Card } from "reactstrap"

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
                <h1>Teacher Dashboard</h1>
            </header>
            
            <section className="home-main">

                <Card className="home-card" onClick={(e) => navigate('students')}>
                    <h3>My Students</h3>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('browse/category')}>
                    <h3>Browse</h3>
                </Card>

                <Card className="home-card" onClick={(e) => navigate('')}>
                    <h3>Assign</h3>
                </Card>
   
            </section>

        </section>
    )
}