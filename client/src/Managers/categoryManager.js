// get all categories
export const getAllCategories = () => {
    return fetch(`/api/category`).then(res => res.json());
}

// get category by id
export const getcategoryById = (id) => {
    return fetch(`/api/category/${id}`).then(res => res.json());
}