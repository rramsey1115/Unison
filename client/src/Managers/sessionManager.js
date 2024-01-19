// get all sessions
export const getAllSessions = () => {
    return fetch(`api/session`).then(res => res.json());
}

// get session by id
export const getSessionById = (id) => {
    return fetch(`api/session/${id}`).then(res => res.json());
}

export const deleteSessionById = (id) => {
    return fetch(`api/session/${id}/delete`, {method: "DELETE" });
}