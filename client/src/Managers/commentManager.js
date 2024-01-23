// get all comments
export const getAllComments = () => {
    return fetch(`/api/comment`).then(res => res.json());
}

// get comment by id
export const getCommentById = (id) => {
    return fetch(`/api/comment/${id}`).then(res => res.json());
}