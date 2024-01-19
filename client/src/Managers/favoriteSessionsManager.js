//  get favorite sessions by musicianId

export const getFavoritesByMusicianId = (id) => {
    return fetch(`api/favoritesessions/${id}`).then(res => res.json());
}