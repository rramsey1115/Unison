import { useEffect, useState } from "react"
import { Accordion, AccordionBody, AccordionHeader, AccordionItem, Button } from "reactstrap"
import { getActivityByCategoryId } from "../../../Managers/activityManager";
import { getcategoryById } from "../../../Managers/categoryManager";
import { useParams } from "react-router-dom";
import { CreateActivityModal } from "../Sessions/CreateSession/CreateActivityModal";

export const BrowseActivities = ({loggedInUser}) => {
    const categoryId = useParams().id;
    const [category, setCategory] = useState({});
    const [activities, setActivities] = useState([]);
    const [open, setOpen] = useState('0');

    useEffect(() => {
        getAndSetActivitiesByCategoryId(categoryId);
        getAndSetCategoryById(categoryId);
    }, [categoryId]);

    const getAndSetActivitiesByCategoryId = (id) => {
        getActivityByCategoryId(id).then(setActivities);
    }

    const getAndSetCategoryById = (id) => {
        getcategoryById(id).then(setCategory);
    }

    const toggle = (id) => {
        if (open === id) { setOpen('0') } 
        else { setOpen(id) }
    };

    return (
        <div className="browse-container">
            <header className="browse-header">
                <div className="header-div">
                    <h1>{category.name}</h1>
                    <CreateActivityModal categoryId={categoryId} getAndSetActivities={getAndSetActivitiesByCategoryId} loggedInUser={loggedInUser}/>
                </div>
                <h5>{category.details}</h5>
            </header>
            <section className="browse-body">

                

                <Accordion open={open} toggle={toggle}>
                    {activities?.map(a => {
                        return (
                        <AccordionItem key={a.id}>
                            <AccordionHeader targetId={`${a.id}`}><h5>{a.name}</h5></AccordionHeader>
                            <AccordionBody accordionId={`${a.id}`}>
                                <div className="accordian-details">
                                    <p>{a.details}</p>
                                </div>
                            </AccordionBody>
                        </AccordionItem>)
                    })}
                </Accordion>
            </section>
        </div>
    )
}