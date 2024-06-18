import { useEffect, useState } from "react";
import "./OrdersView.css"

import { Button, Card, CardBody, CardImg, CardText, Col, Row } from "reactstrap";
import moment from 'moment';
import { getOrdersForAdmins } from "../../managers/orderManager";


export default function OrdersView() {

    const [orders, setOrders] = useState([])

    const getAndSetOrders = () => {
        getOrdersForAdmins().then(setOrders);

    }

    useEffect(() => {
        getAndSetOrders();
    }, []);



    return (
        <>
            <div className="header-tag">
                <h2>Orders</h2>
            </div>
            <div className="order-card-container">
                {orders.map((order) => (
                    <Card key={order.id} className="order-card my-3">
                        <Row className="g-0 align-items-center">
                            <Col xs="4">
                                {order.orderRoses.map((or, index) => (
                                    <Row key={index} className="mb-2">
                                        <Col xs="6">
                                            <CardImg src={or.rose.image} alt="Order Rose Image" />
                                        </Col>
                                        <Col xs="6">
                                            <Row>
                                                <Col xs="12" className="rose-name" >
                                                    <CardText id="rose-name">
                                                        <strong>{or.rose.name}</strong>
                                                    </CardText>
                                                </Col>
                                                <Col xs="12" className="rose-quantity">
                                                    <CardText className="small mb-1" id = "qty">
                                                        qty: {or.quantity}
                                                    </CardText>
                                                </Col>
                                            </Row>
                                        </Col>
                                    </Row>
                                ))}
                            </Col>
                            <Col xs="8">
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
                                    <Col className="mt-3">
                                        {!order.isFulfilled && (
                                            <Button
                                                id ="fulfill-btn"
                                               
                                            >
                                                Fulfill
                                            </Button>
                                        )}
                                    </Col>
                                </CardBody>
                            </Col>
                        </Row>
                    </Card>
                ))}
            </div>
        </>
    );

}