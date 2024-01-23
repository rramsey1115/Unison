// get all activities
export const getAllactivities = () => {
    return fetch(`/api/activity`).then(res => res.json());
}

// get activity by categoryId
export const getActivityByCategoryId = (id) => {
    return fetch(`/api/activity/category/${id}`).then(res => res.json());
}

// get activity by activityId
export const getActivityById = (id) => {
    return fetch(`/api/activity/${id}`).then(res => res.json());
}