// get all assignments
export const getAllassignments = () => {
    return fetch(`api/assignment`).then(res => res.json());
}

// get assignment by id
export const getAssignmentById = (id) => {
    return fetch(`api/assignment/${id}`).then(res => res.json());
}