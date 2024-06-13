
import { useEffect, useState } from "react";
import "./OrderConfirmation.css"
import { getUserById } from "../managers/userManager";
import { Card, CardBody, CardText, Col, Row } from "reactstrap";
import moment from 'moment';


export default function ProfileView({ loggedInUser }) {

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
                <h4>{user.address}</h4>
            </div>
            <div className="order-card-container">
                {user.orders?.filter(order => !order.isActive).map((order) => (
                    <Card key={order.id} className="order-card my-3">
                        <Row className="g-0 align-items-center">
                            <CardBody className="text-center">
                                <CardText className="mb-0 rose-name">
                                    <strong>Order placed: {moment(order.purchaseDate).format('DD MMM YYYY')}</strong>
                                </CardText>
                                <CardText className="mb-0 price">
                                    <strong>Order total: ${order.total}</strong>
                                </CardText>
                                <CardText className="mb-0 price">
                                    <strong>Has Shipped: {order.isFulfilled ? 'true' : 'false'}</strong>
                                </CardText>
                            </CardBody>

                        </Row>
                    </Card>
                ))}
            </div>

        </>
    );

}