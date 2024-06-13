import { Route, Routes } from "react-router-dom";

import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import AllRoses from "./rose/AllRoses";
import RoseDetails from "./rose/RoseDetails";
import CartView from "./cart/CartView";
import OrderConfirmation from "./OrderConfirmation";
import ProfileView from "./ProfileView";
import Whoops from "./Whoops";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <AllRoses />
            </AuthorizedRoute>
          }
        />
        <Route
          path="rose/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <RoseDetails loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="cart"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <CartView loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="userProfile"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ProfileView loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="orderConfirmation"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <OrderConfirmation loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="add-inventory"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
              <>Create a new Rose</>
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
      <Route path="*" element={<Whoops />} />
    </Routes>
  );
}
