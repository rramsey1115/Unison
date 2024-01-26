import { useEffect, useState } from "react"
import { getAllCategories } from "../../../../Managers/categoryManager";
import { getActivityByCategoryId, getActivityById } from "../../../../Managers/activityManager";
import "./CreateSession.css";
import { CreateActivityModal } from "./CreateActivityModal";
import { Button } from "reactstrap";

export const SessionActivitySelect = ({newSession, setNewSession, loggedInUser}) => {
    const [categories, setCategories] = useState([]);
    const [categoryId, setCategoryId] = useState(0);
    const [activityId, setActivityId] = useState(0);
    const [duration, setDuration] = useState(0)
    const [buttonHidden, setButtonHidden] = useState(true);
    const [activities, setActivities] = useState([]);

    useEffect(() => {getAndSetCategories() }, [categoryId]);

    const getAndSetCategories = () => {
        getAllCategories().then(setCategories);
    };

    const getAndSetActivities = (id) => {
        if(id > 0) {getActivityByCategoryId(id).then(setActivities);}
    };

    const handleCategoryChange = (e) => {
        setCategoryId(e.target.value*1);
        if(e.target.value*1 > 0) { getAndSetActivities(e.target.value*1); }
    }

    const handleDurationChange = (e) => {
        setDuration(e.target.value*1);
        if(e.target.value*1 > 0)
        {
            setButtonHidden(false);
        }
        if(e.target.value*1 === 0)
        {
            setButtonHidden(true);
        }
    }

    const handleAdd =async (e) => {
        e.preventDefault();
        var activity = {};
        const copy = {...newSession};
        activity = await getActivityById(activityId);
        copy.sessionActivities.push(
        {
            activityId: activityId,
            activity: activity,
            duration: duration,
        });
        setNewSession(copy);
        setButtonHidden(true);
        setCategoryId(0);
        setActivityId(0);
        setDuration(0);
    }

    return (
    <div>
        <select 
            value={categoryId}
            onChange={(e)=> {
                handleCategoryChange(e)
            }}>
            <option value={0}>Categories</option>
            {categories.map(c => {
                return ( 
                <option 
                    key={c.id}
                    value={c.id}
                >
                    {c.name}
                </option>)
            })}
        </select>
   
        {categoryId > 0 
        ? <select
                onChange={(e) => setActivityId(e.target.value*1)}>
                <option value={0}>Activities</option>
                {activities?.map(a => {
                    return ( 
                    <option 
                        key={a.id}
                        value={a.id}
                    >
                        {a.name}
                    </option>)
                })}
            </select>
        : null
        }

        <CreateActivityModal categoryId={categoryId} getAndSetActivities={getAndSetActivities} loggedInUser={loggedInUser}/>

        {categoryId > 0 && activityId > 0 
        ? <select
            onChange={(e) => handleDurationChange(e)}>
            <option value={0}>Minutes</option>
            {Array.from({ length: 60 }, (_, index) => (
                <option 
                    key={index+1} 
                    value={index+1}
                >{index+1}
                </option>
            ))}
        </select>
        : null
        }

        {buttonHidden === true 
        ? null 
        :<Button size="sm" color="info" onClick={(e) => handleAdd(e)}>Add Activity</Button>
        }

    </div>)
}