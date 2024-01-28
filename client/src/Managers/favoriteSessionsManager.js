//  get favorite sessions by musicianId
export const getFavoritesByMusicianId = (id) => {
    return fetch(`/api/favoritesession/${id}`).then(res => res.json());
}