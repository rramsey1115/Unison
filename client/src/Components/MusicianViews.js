import { Route, Routes } from "react-router-dom";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import { Home } from "./MusicianViews/Home";
import { MySessions } from "./MusicianViews/Sessions/MySessions/MySessions";
import { CreateSession } from "./MusicianViews/Sessions/CreateSession/CreateSession";
import { ActiveSession } from "./MusicianViews/Sessions/ActiveSession/ActiveSession";
import { BrowseCategories } from "./MusicianViews/Browse/BrowseCategories";
import { BrowseActivities } from "./MusicianViews/Browse/BrowseActivities";
import { Assignments } from "./MusicianViews/Assignments/Assignments";
import { StudentProfile } from "./MusicianViews/Profile/StudentProfile";

export const MusicianViews = ({ loggedInUser, setLoggedInUser }) => {
  return (
    <Routes>
      <Route path="/">
      
        <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <Home loggedInUser={loggedInUser}/>
              </AuthorizedRoute>
            }
        />

        <Route path="session">
          <Route index loggedInUser={loggedInUser} element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <MySessions loggedInUser={loggedInUser}/>
            </AuthorizedRoute>} 
          />
          <Route path=":id" loggedInUser={loggedInUser} element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ActiveSession loggedInUser={loggedInUser}/>
            </AuthorizedRoute>}
          />
          <Route path="create" loggedInUser={loggedInUser} element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CreateSession loggedInUser={loggedInUser}/>
            </AuthorizedRoute>}
          />
        </Route>


        <Route path="profile">
          <Route path=":id" loggedInUser={loggedInUser} element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <StudentProfile loggedInUser={loggedInUser} />
            </AuthorizedRoute>}
          />
        </Route>

        <Route path="assignments">
          <Route path=":id" element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Assignments loggedInUser={loggedInUser} />
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
