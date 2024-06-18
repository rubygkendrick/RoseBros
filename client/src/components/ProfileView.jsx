
import { useEffect, useState } from "react";
import "./OrderConfirmation.css"
import { getUserById } from "../managers/userManager";
import { Card, CardBody, CardImg, CardText, Col, Row } from "reactstrap";
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
                        <Row className="g-0 align-items-center"  >
                            <Col xs="4">
                                {order.orderRoses.map((or, index) => (
                                    <Row key={index} className="mb-2" >
                                        <Col xs="8">
                                            <CardImg src={or.rose.image} alt="Order Rose Image" />
                                        </Col>
                                        <Col xs="12">
                                            <Row>
                                                <Col xs="8">
                                                    <Row>
                                                        <Col xs="12">
                                                            <CardText id="rose-name">
                                                                <strong>{or.rose.name}</strong>
                                                            </CardText>
                                                        </Col>
                                                        <Col xs="12" className="rose-quantity">
                                                            <CardText className="small mb-1" id="qty">
                                                                qty: {or.quantity}
                                                            </CardText>
                                                        </Col>
                                                    </Row>
                                                </Col>
                                            </Row>
                                        </Col>
                                    </Row>
                                ))}
                            </Col>
                            <Col xs="6">
                                <CardBody className="text-center">
                                    <CardText className="mb-2">
                                        Order placed: <strong>{moment(order.purchaseDate).format('DD MMM YYYY')}</strong>
                                    </CardText>
                                    <CardText className="mb-2">
                                        Order total: <strong>${order.total}</strong>
                                    </CardText>
                                    <CardText className={`mb-2 ${!order.isFulfilled ? 'text-danger' : ''}`}>
                                        Order Delivered: <strong>{order.isFulfilled ? 'true' : 'false'}</strong>
                                    </CardText>
                                </CardBody>
                            </Col>
                        </Row>
                    </Card>
                ))}
            </div>

        </>
    );

}