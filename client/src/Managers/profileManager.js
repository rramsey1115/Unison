// get all users
export const getAllUsers = () => {
    return fetch(`/api/userprofile`).then(res => res.json());
}

export const getUsersWithRoles = () => {
    return fetch(`/api/userprofile/withroles`).then(res => res.json());
}