import { useEffect, useState } from "react"
import { getAllCategories } from "../../../Managers/categoryManager";
import "./Browse.css";
import { Accordion, AccordionBody, AccordionHeader, AccordionItem, Button } from 'reactstrap';
import { useNavigate } from "react-router-dom";
import { EditCategoryModal } from "./EditCategoryModal";


export const BrowseCategories = ({loggedInUser}) => {
    const [categories, setCategories] = useState([]);
    const [open, setOpen] = useState('0');

    useEffect(() => {
        getAndSetAllCategories();
    }, []);

    const getAndSetAllCategories = () => {
        getAllCategories().then(setCategories);
    }

    const toggle = (id) => {
        if (open === id) { setOpen('0') } 
        else { setOpen(id) }
    };

    const navigate = useNavigate();

    console.log(loggedInUser);

    return (
        <div className="browse-container">
            <header className="browse-header">
                <h1>Browse Categories</h1>
            </header>
            <section className="browse-body">
                <Accordion open={open} toggle={toggle}>
                    {categories.map(c => {
                        return (
                        <AccordionItem key={c.id}>
                            <AccordionHeader targetId={`${c.id}`}><h5>{c.name}</h5></AccordionHeader>
                            <AccordionBody accordionId={`${c.id}`}>
                                <p>{c.details}</p>
                                <div className="accordion-btns">
                                    <Button
                                        id="explore-category-btn" 
                                        className="explore-btn"
                                        color="info"
                                        size="sm"
                                        value={c.id}
                                        onClick={(e) => navigate(`${e.target.value}`) }
                                    >Explore
                                    </Button>
                                    {loggedInUser.roles[0] !== "Teacher" 
                                    ? null 
                                    : <EditCategoryModal categoryId={c.id} getAndSetAllCategories={getAndSetAllCategories}/>}
                                </div>
                            </AccordionBody>
                        </AccordionItem>)
                    })}
                </Accordion>
            </section>
        </div>
    )
}