
import "./OrderConfirmation.css"

export default function OrderConfirmation({loggedInUser}) {

 const user = loggedInUser;
  
 


    return (
        <>
        <div className="header-tag">
            <h2>Your Order has been placed!</h2>
        </div>
        <div className="message">
            <h4>an email confirmation has been sent to {user.email}</h4>
        </div>   
        </>
    );

}