// get all activities
export const getAllactivities = () => {
    return fetch(`/api/activity`).then(res => res.json());
}

// get activity by id
export const getActivityByCategoryId = (id) => {
    return fetch(`/api/activity/${id}`).then(res => res.json());
}