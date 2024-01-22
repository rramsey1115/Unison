import { useEffect, useState } from "react"
import { getAllCategories } from "../../../../Managers/categoryManager";
import { getActivityByCategoryId } from "../../../../Managers/activityManager";

export const SessionActivitySelect = ({newSession, setNewSession}) => {
    const [categories, setCategories] = useState([]);
    const [categoryId, setCategoryId] = useState(0);
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

    console.log(activities);


    return (
    <>
        <select 
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
        ? <select>
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
        : null
        }
    </>)
}