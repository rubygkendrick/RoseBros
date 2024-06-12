
import { useEffect, useState } from "react";
import "./OrderConfirmation.css"
import { getUserById } from "../managers/userManager";

export default function ProfileView({loggedInUser}) {

 const [user, setUser] = useState({})

 const getAndSetUser = () => {
    // eslint-disable-next-line react/prop-types
    getUserById(loggedInUser.id).then(setUser);
 }


 useEffect(() => {
    getAndSetUser();
}, []);

  



    return (
        <>
        <div className="header-tag">
            <h2>{user.firstName} {user.lastName}</h2>
        </div>
        <div className="message">
            <h4>{user.email}</h4>
        </div>   
        </>
    );

}