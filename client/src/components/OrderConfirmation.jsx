/* eslint-disable react/prop-types */
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import moment from 'moment';
import "./OrderConfirmation.css";
import { getUserById } from '../managers/userManager';

export default function OrderConfirmation({ loggedInUser }) {
    const navigate = useNavigate();


    const [user, setUser] = useState({})

    const getAndSetUser = () => {
        getUserById(loggedInUser.id).then(setUser);
    };

    useEffect(() => {
        getAndSetUser();
    }, []);


    useEffect(() => {
        // Check if the recent purchase flag is set
        const recentPurchase = sessionStorage.getItem('recentPurchase');

        if (recentPurchase === 'true') {
            // Remove the flag after checking
            sessionStorage.removeItem('recentPurchase');
        } else {
            // If no recent purchase, redirect to not allowed page
            navigate('/notAllowed');
        }
    }, [navigate]);

    return (
        <>
            <div className="header-tag">
                <h2>Your Order has been placed!</h2>
            </div>
            <div className="message">
                <h4>An email confirmation has been sent to {user.email}</h4>
            </div>
        </>
    );
}
