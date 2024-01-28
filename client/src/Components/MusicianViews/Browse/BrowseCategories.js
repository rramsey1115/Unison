import { useEffect, useState } from "react"
import { deleteCategoryById, getAllCategories } from "../../../Managers/categoryManager";
import "./Browse.css";
import { Accordion, AccordionBody, AccordionHeader, AccordionItem, Button } from 'reactstrap';
import { useNavigate } from "react-router-dom";
import { EditCategoryModal } from "./EditCategoryModal";
import { CreateCategoryModal } from "./CreateCategoryModal";
import { ConfirmDeleteCatModal } from "./ConfirmDeleteCatModal";
import { ScaleLoader } from "react-spinners";


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
        deleteCategoryById(e.target.value*1).then(() => getAndSetAllCategories());
    }

    const navigate = useNavigate();

    return (
    categories.length === 0
    ? 
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <div className="browse-container">
            <div id="browse-category-header" className="browse-header">
                <h1>Browse Categories</h1>
                {loggedInUser.roles[0]!=="Teacher" ? null
                :<CreateCategoryModal loggedInUser={loggedInUser} getAndSetAllCategories={getAndSetAllCategories}/> }
            </div>
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
                                    :<ConfirmDeleteCatModal category={c} handleDeleteCategory={handleDeleteCategory}/>
                                    }
                                </div>
                            </AccordionBody>
                        </AccordionItem>)
                    })}
                </Accordion>
            </section>
        </div>
    )
}