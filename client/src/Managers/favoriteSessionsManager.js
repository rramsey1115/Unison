//  get favorite sessions by musicianId
export const getFavoritesByMusicianId = (id) => {
    return fetch(`/api/favoritesession/${id}`).then(res => res.json());
}

// add session to favorites by musicianId & sessionId foreign keys
export const addFavorite = (obj) => {
    return fetch(`/api/favoritesession`, {
        method: "POST",
        headers: { "Content-Type":"application/json"},
        body: JSON.stringify(obj)
    });
}

// remove session from favorites by favoriteSessionId primary key
export const removeFavorite = (id) => {
    return fetch(`/api/favoritesession/${id}`, { method:"DELETE" });
}