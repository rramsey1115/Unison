// get all sessions
export const getAllSessions = () => {
    return fetch(`/api/session`).then(res => res.json());
}

// get session by id
export const getSessionById = (id) => {
    return fetch(`/api/session/${id}`).then(res => res.json());
}

// delete session by id
export const deleteSessionById = (id) => {
    return fetch(`/api/session/${id}/delete`, {method: "DELETE" });
}

// create a new session
export const createNewSession = (obj) => {
    return fetch(`/api/session`, {
        method: "POST",
        headers: { "Content-Type":"application/json" },
        body: JSON.stringify(obj)
    }).then(res => res.json());
}

// edit session - used to add notes at end of active session
export const completeSession = (obj) => {
    return fetch(`/api/session/${obj.id}/complete`, {
        method: "PUT",
        headers: {"Content-Type":"application/json"},
        body: JSON.stringify(obj)
    });
}