import { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { Spinner } from "reactstrap";
import NavBar from "./Components/navbar/NavBar";
import { tryGetLoggedInUser } from "./Managers/authManger";
import { TeacherViews } from "./Components/TeacherViews.js";
import { MusicianViews } from "./Components/MusicianViews.js";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    loggedInUser.roles[0] == "Teacher" 
    ?<>
      <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
      <TeacherViews loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
    </>
    :
    <>
      <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
      <MusicianViews loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
    </>
  );
}

export default App;

{/* {console.log(loggedInUser)}
{loggedInUser.roles[0] = "Teacher" 
? <TeacherViews loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} /> */}

{/* :  */}