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
        if (user.orders && user.orders.length > 0) {
            const hasRecentPurchase = user.orders.some(order => {
                const purchaseDate = moment(order.purchaseDate);
                const today = moment().startOf('day');
                return purchaseDate.isSame(today, 'day');
            });

            if (!hasRecentPurchase) {
                navigate('/notAllowed');
            }
        } else {
            navigate('/notAllowed'); // Navigate to profile if there are no orders
        }
    }, [user, navigate]);

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
