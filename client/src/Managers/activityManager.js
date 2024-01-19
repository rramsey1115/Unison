// get all activities
export const getAllactivities = () => {
    return fetch(`api/activity`).then(res => res.json());
}

// get activity by id
export const getActivityById = (id) => {
    return fetch(`api/activity/${id}`).then(res => res.json());
}