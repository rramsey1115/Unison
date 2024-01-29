import { Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import { BrowseCategories } from "./MusicianViews/Browse/BrowseCategories";
import { BrowseActivities } from "./MusicianViews/Browse/BrowseActivities";
import { TeacherHome } from "./TeacherViews/TeacherHome";
import { StudentSessions } from "./TeacherViews/Sessions/StudentSessions";
import { Students } from "./TeacherViews/MyStudents/Students";
import { CreateAssignment } from "./TeacherViews/Assignments/CreateAssignment";
import { Assignments } from "./MusicianViews/Assignments/Assignments";
// import { FavoriteSessions } from "./MusicianViews/Sessions/MySessions/FavoriteSession";

export const TeacherViews = ({ loggedInUser, setLoggedInUser }) => {
  return (
    <Routes>
        <Route path="/">

            <Route index element={
                <AuthorizedRoute roles={["Teacher"]} loggedInUser={loggedInUser}>
                    <TeacherHome loggedInUser={loggedInUser}/>
                </AuthorizedRoute>}
            />

            <Route path="students">   
                <Route index element={
                    <AuthorizedRoute roles={["Teacher"]} loggedInUser={loggedInUser}>
                        <Students loggedInUser={loggedInUser}/>
                    </AuthorizedRoute>} 
                />

                <Route path="sessions/:id" element={
                    <AuthorizedRoute roles={["Teacher"]} loggedInUser={loggedInUser}>
                        <StudentSessions loggedInUser={loggedInUser}/>
                    </AuthorizedRoute>}
                />
            </Route>


            <Route path="assignments">
                <Route path=":id" element={
                    <AuthorizedRoute loggedInUser={loggedInUser}>
                        <Assignments loggedInUser={loggedInUser}/>
                    </AuthorizedRoute>
                }/>
                <Route path="create" element={
                    <AuthorizedRoute roles={["Teacher"]} loggedInUser={loggedInUser}>
                        <CreateAssignment loggedInUser={loggedInUser} />
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
