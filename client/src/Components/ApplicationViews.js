import { Route, Routes } from "react-router-dom";
import Bikes from "./bikes/Bikes";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import WorkOrderList from "./workorders/WorkOrderList";
import CreateWorkOrder from "./workorders/CreateWorkOrder";
import UserProfileList from "./userprofiles/UserProfileList";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />

        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        
        <Route path="*" element={<p>Whoops, nothing here...</p>} />
      </Route>
    </Routes>
  );
}
