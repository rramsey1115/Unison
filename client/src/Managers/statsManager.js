// return stats DTO based on userId
export const getStatsByUserId = (id) => {
    return fetch(`/api/stats/${id}`).then(res => res.json());
}
