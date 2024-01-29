import { useEffect, useState } from "react"
import { Accordion, AccordionBody, AccordionHeader, AccordionItem, Button, Input } from "reactstrap"
import { deleteActivityById, getActivityByCategoryId } from "../../../Managers/activityManager";
import { getcategoryById } from "../../../Managers/categoryManager";
import { useParams } from "react-router-dom";
import { CreateActivityModal } from "../Sessions/CreateSession/CreateActivityModal";
import { EditActivityModal } from "./EditActivityModal";
import { ScaleLoader } from "react-spinners";

export const BrowseActivities = ({loggedInUser}) => {
    const categoryId = useParams().id;
    const [category, setCategory] = useState({});
    const [activities, setActivities] = useState([]);
    const [open, setOpen] = useState('0');
    const [filterText, setFilterText] = useState("");

    useEffect(() => {
        getAndSetActivitiesByCategoryId(categoryId);
        getAndSetCategoryById(categoryId);
    }, [categoryId, filterText]);

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

    const handleDeleteActivity = (e) => {
        e.preventDefault();
        deleteActivityById(e.target.value*1).then(() => getAndSetActivitiesByCategoryId(categoryId))
    }

    return (
    !activities || !category.details
    ? 
        <div className="spinner-container">
            <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
        </div>
    :
        <div className="browse-container">
            <header className="browse-header">
                <h1>{category.name}</h1>
                <h5>{category.details}</h5>
                <div className="header-div">
                    <CreateActivityModal categoryId={categoryId} getAndSetActivities={getAndSetActivitiesByCategoryId} loggedInUser={loggedInUser}/>
                    <Input
                        type="text"
                        id="sessions-search-input"
                        className="search-input"
                        placeholder="Search"
                        value={filterText}
                        onChange={(e) => {
                            setFilterText(e.target.value);
                        }}
                    />
                </div>
            </header>
            <section className="browse-body">

                <Accordion open={open} toggle={toggle}>
                    {activities.map(a => {
                        return (
                        <AccordionItem key={a.id}>
                            <AccordionHeader targetId={`${a.id}`}><h5>{a.name}</h5></AccordionHeader>
                            <AccordionBody accordionId={`${a.id}`}>
                                <p>{a.details}</p>
                                <div className="accordion-btns">
                                    {loggedInUser.roles[0] === "Teacher" || loggedInUser.id === a.creatorId 
                                    ?<Button
                                        id="delete-activity-btn"
                                        className="delete-btn"
                                        size="sm"
                                        color="secondary"
                                        value={a.id}
                                        onClick={(e) => handleDeleteActivity(e)}
                                    >Delete
                                    </Button>
                                    : null}
                                    {loggedInUser.roles[0] === "Teacher" || loggedInUser.id === a.creatorId 
                                    ?<EditActivityModal activityId={a.id} categoryId={categoryId} getAndSetActivitiesByCategoryId={getAndSetActivitiesByCategoryId} loggedInUser={loggedInUser}/>
                                    : null}
                                </div>
                            </AccordionBody>
                        </AccordionItem>)
                    })}
                </Accordion>
            </section>
        </div>
    )
}