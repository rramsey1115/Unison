import { useEffect, useState } from "react"
import { getAllCategories } from "../../../Managers/categoryManager";
import "./Browse.css";
import { Accordion, AccordionBody, AccordionHeader, AccordionItem, Button } from 'reactstrap';
import { useNavigate } from "react-router-dom";


export const BrowseCategories = ({loggedInUser}) => {
    const [categories, setCategories] = useState([]);
    const [open, setOpen] = useState('');

    useEffect(() => {
        getAndSetAllCategories();
    }, []);

    const getAndSetAllCategories = () => {
        getAllCategories().then(setCategories);
    }

    const toggle = (id) => {
        if (open === id) { setOpen() } 
        else { setOpen(id) }
    };

    const navigate = useNavigate();

    return (
        <div className="browse-container">
            <header className="browse-header">
                <h1>Browse Categories</h1>
            </header>
            <section className="browse-body">
                <Accordion open={open} toggle={toggle}>
                    {categories.map(c => {
                        return (
                        <AccordionItem>
                            <AccordionHeader targetId={c.id}><h5>{c.name}</h5></AccordionHeader>
                            <AccordionBody accordionId={c.id}>
                                <div className="accordian-details">
                                    <h5>{c.details}</h5>
                                    <Button
                                        id="explore-category-btn" 
                                        className="explore-btn"
                                        color="info"
                                        value={c.id}
                                        onClick={(e) => navigate(`${e.target.value}`) }
                                    >Explore
                                    </Button>
                                </div>
                            </AccordionBody>
                        </AccordionItem>)
                    })}
                </Accordion>
            </section>
        </div>
    )
}