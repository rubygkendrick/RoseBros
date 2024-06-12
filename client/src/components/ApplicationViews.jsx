import { Route, Routes } from "react-router-dom";

import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import AllRoses from "./rose/AllRoses";
import RoseDetails from "./rose/RoseDetails";
import CartView from "./cart/CartView";


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
          path="rose/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <RoseDetails loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
        />
        <Route
          path="cart"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CartView loggedInUser={loggedInUser}/>
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
          path="orderConfirmation"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <>Order Confirmation</>
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
