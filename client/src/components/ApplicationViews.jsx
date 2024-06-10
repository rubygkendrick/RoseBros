import { Route, Routes } from "react-router-dom";

import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import AllRoses from "./rose/AllRoses";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <AllRoses/>
            </AuthorizedRoute>
          }
        />
        <Route
          path="cart"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <>Cart View </>
            </AuthorizedRoute>
          }
        />
        <Route
          path="userProfile"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <>Profile View</>
            </AuthorizedRoute>
          }
        />


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
