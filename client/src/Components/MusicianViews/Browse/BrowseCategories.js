import { useEffect, useState } from "react"
import { deleteCategoryById, getAllCategories } from "../../../Managers/categoryManager";
import "./Browse.css";
import { Accordion, AccordionBody, AccordionHeader, AccordionItem, Button } from 'reactstrap';
import { useNavigate } from "react-router-dom";
import { EditCategoryModal } from "./EditCategoryModal";
import { CreateCategoryModal } from "./CreateCategoryModal";


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

    const handleDeleteCategory = (e) => {
        e.preventDefault();
        deleteCategoryById(e.target.value*1).then(() => getAndSetAllCategories());
    }

    const navigate = useNavigate();

    return (
        <div className="browse-container">
            <header id="browse-category-header" className="browse-header">
                <h1>Browse Categories</h1>
                <CreateCategoryModal loggedInUser={loggedInUser} getAndSetAllCategories={getAndSetAllCategories}/>
            </header>
            <section className="browse-body">
                <Accordion open={open} toggle={toggle}>
                    {categories?.map(c => {
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
                                    :<EditCategoryModal categoryId={c.id} getAndSetAllCategories={getAndSetAllCategories}/>
                                    }
                                    {loggedInUser.roles[0] !== "Teacher" 
                                    ? null 
                                    :<Button
                                        id="delete-category-btn"
                                        className="delete-btn"
                                        color="secondary"
                                        size="sm"
                                        value={c.id}
                                        onClick={(e) => handleDeleteCategory(e)}
                                    >Delete
                                    </Button>}
                                </div>
                            </AccordionBody>
                        </AccordionItem>)
                    })}
                </Accordion>
            </section>
        </div>
    )
}