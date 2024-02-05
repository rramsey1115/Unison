import { useState } from "react"
import { ScaleLoader } from "react-spinners";

export const FavoriteSessions = () => {
    const [favorites, setFavorites] = useState([]);

    const getAndSetFavorites = () => {
        
    }

    return (
        favorites.length === 0
        ? 
            <div className="spinner-container">
                <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />
            </div>
        :
        <div className="favorites-container">

            <header className="favorites-header">
                <h2>FavoriteActivities</h2>
            </header>

            <section className="favorites-main">

            </section>
      
        </div>
    )
}