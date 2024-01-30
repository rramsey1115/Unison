import { useEffect, useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import NavBar from "./Components/navbar/NavBar";
import { tryGetLoggedInUser } from "./Managers/authManger";
import { TeacherViews } from "./Components/TeacherViews.js";
import { MusicianViews } from "./Components/MusicianViews.js";
import { ScaleLoader } from "react-spinners";

export const App = () => {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <ScaleLoader color="#58b7dd" height={50} margin={3} radius={2} width={5} />;
  }

  return (
    loggedInUser?.roles?.includes("Teacher")
    ?
      <>
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
