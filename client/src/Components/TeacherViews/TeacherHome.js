import { useNavigate } from "react-router-dom"
import { Card } from "reactstrap"

export const TeacherHome = () => {

    const navigate = useNavigate();

    return (
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

                {/* <Card className="home-card" onClick={(e) => navigate('')}>
                    <h3>Assign</h3>
                </Card> */}
   
            </section>

        </section>
    )
}