import { useEffect, useState } from "react";
import "./OrdersView.css"

import { Card, CardBody, CardText, Col, Row } from "reactstrap";
import moment from 'moment';


export default function OrdersView() {

    const [orders, setOrders] = useState({})

    const getAndSetOrders = () => {
        
       
    }



    return (
        <>
            <div className="header-tag">
                <h2>Orders</h2>
            </div>
            <div className="order-card-container">
                {orders.filter(order => !order.isActive).map((order) => (
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