import { useEffect, useState } from "react"
import { getAllCategories } from "../../../../Managers/categoryManager";
import { getActivityByCategoryId, getActivityById } from "../../../../Managers/activityManager";
import "./CreateSession.css";
import { CreateActivityModal } from "./CreateActivityModal";

export const SessionActivitySelect = ({newSession, setNewSession, loggedInUser}) => {
    const [categories, setCategories] = useState([]);
    const [categoryId, setCategoryId] = useState(0);
    const [activityId, setActivityId] = useState(0);
    const [duration, setDuration] = useState(0)
    const [buttonHidden, setButtonHidden] = useState(true);
    const [activities, setActivities] = useState([]);

    useEffect(() => { getAndSetCategories() }, []);

    const getAndSetCategories = () => {
        getAllCategories().then(setCategories);
    };

    const getAndSetActivities = (id) => {
        getActivityByCategoryId(id).then(setActivities);
        console.log(activities)
    };

    const handleCategoryChange = (e) => {
        setCategoryId(e.target.value*1);
        if(e.target.value > 0) { getAndSetActivities(e.target.value*1) }
    }

    const handleDurationChange = (e) => {
        setDuration(e.target.value*1);
        setButtonHidden(false);
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
    <>

        <select 
            value={categoryId}
            onChange={(e)=> {
                handleCategoryChange(e)
            }}>
            <option>Categories</option>
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

<br/>

        {categoryId > 0 
        ? <>
            <select
                onChange={(e) => setActivityId(e.target.value*1)}>
                <option>Activities</option>
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
 
            <CreateActivityModal categoryId={categoryId} getAndSetActivities={getAndSetActivities} loggedInUser={loggedInUser}/>
            
        </>
        : null
        }

<br/>

        {categoryId > 0 && activityId > 0 
        ? <select
            onChange={(e) => handleDurationChange(e)}>
            <option>Minutes</option>
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

<br/>

        {buttonHidden === true 
        ? null 
        :<button onClick={(e) => handleAdd(e)}>Add Activity</button>
        }


    </>)
}