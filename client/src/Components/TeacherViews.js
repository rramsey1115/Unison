import { Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import { BrowseCategories } from "./MusicianViews/Browse/BrowseCategories";
import { BrowseActivities } from "./MusicianViews/Browse/BrowseActivities";
import { FavoriteActivities } from "./MusicianViews/Browse/FavoriteActivities";
import { TeacherHome } from "./TeacherViews/TeacherHome";
import { MyStudents } from "./TeacherViews/MyStudents/MyStudents";
import { StudentSessions } from "./TeacherViews/Sessions/StudentSessions";


export const TeacherViews = ({ loggedInUser, setLoggedInUser }) => {
  return (
    <Routes>
        <Route path="/">

            <Route index element={
                <AuthorizedRoute roles={["Teacher"]} loggedInUser={loggedInUser}>
                    <TeacherHome loggedInUser={loggedInUser}/>
                </AuthorizedRoute>}
            />

            <Route path="mystudents">   
                <Route index element={
                    <AuthorizedRoute roles={["Teacher"]} loggedInUser={loggedInUser}>
                        <MyStudents loggedInUser={loggedInUser}/>
                    </AuthorizedRoute>} 
            />

            <Route path="sessions/:id" element={
                <AuthorizedRoute roles={["Teacher"]} loggedInUser={loggedInUser}>
                    <StudentSessions loggedInUser={loggedInUser}/>
                </AuthorizedRoute>}
            />
            </Route>
      
            <Route path="browse">
                <Route path="category" element={
                    <AuthorizedRoute loggedInUser={loggedInUser}>
                        <BrowseCategories loggedInUser={loggedInUser}/>
                    </AuthorizedRoute>}
                />
                <Route path="category/:id" element={
                    <AuthorizedRoute loggedInUser={loggedInUser}>
                        <BrowseActivities loggedInUser={loggedInUser}/>
                    </AuthorizedRoute>}
                />
            </Route>

            <Route path="favorite">
                <Route index element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                    <FavoriteActivities loggedInUser={loggedInUser} />
                </AuthorizedRoute>}
                />
            </Route>

            <Route
                path="login"
                element={<Login setLoggedInUser={setLoggedInUser} />}
            />

            <Route
                path="register"
                element={<Register setLoggedInUser={setLoggedInUser} />}
            />

        </Route>

      <Route path="*" element={<p>Whoops, nothing here...</p>} />

    </Routes>
  );
}
