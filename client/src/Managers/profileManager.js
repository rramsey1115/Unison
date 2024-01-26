// get all users
export const getAllUsers = () => {
    return fetch(`/api/userprofile`).then(res => res.json());
}

// get all users with roles
export const getUsersWithRoles = () => {
    return fetch(`/api/userprofile/withroles`).then(res => res.json());
}

// get students by teacherId
export const getTeacherStudents = (teacherId) => {
    return fetch(`/api/userprofile/teacher/${teacherId}`).then(res => res.json());
}

// remove teacherId from student
export const removeTeacherIdFromStudent = (studentId) => {
    return fetch(`/api/userprofile/remove/${studentId}`, {
        method: "POST"
    }).then(res => res.json)
}

// get user by id
export const getUserById = (id) => {
    return fetch(`/api/userprofile/${id}`).then(res => res.json());
}