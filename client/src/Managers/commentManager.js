// get all comments
export const getAllComments = () => {
    return fetch(`/api/comment`).then(res => res.json());
}

// get comment by id
export const getCommentById = (id) => {
    return fetch(`/api/comment/${id}`).then(res => res.json());
}

// post new comment
export const postNewComment = (obj) => {
    return fetch(`/api/comment`, {
        method: "POST",
        headers: { "Content-Type":"application/json" },
        body: JSON.stringify(obj)
    }).then(res => res.json());
}

// delete comment by id
export const deleteComment = (id) => {
    return fetch(`/api/comment/${id}`, {
        method: "DELETE"
    });
}