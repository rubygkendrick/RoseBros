/* eslint-disable react/prop-types */
import { useState, useEffect } from "react";
import "./CartView.css"
import { useNavigate } from "react-router-dom";
import { FaTrashAlt } from 'react-icons/fa';

import { Button, Card, CardBody, CardImg, CardText, Col, Input, Row } from "reactstrap";
import { getActiveOrderByUserId } from "../../managers/orderManager";



// eslint-disable-next-line react/prop-types
export default function CartView({ loggedInUser }) {
    const [order, setOrder] = useState([]);
    const [modal, setModal] = useState(false);


    const navigate = useNavigate();
    const toggleModal = () => setModal(!modal);

    const getAndResetOrder = () => {
        getActiveOrderByUserId(loggedInUser.id).then(setOrder);
    };

    useEffect(() => {
        getAndResetOrder();
    }, []);

    return (
        <div>
        <div className="order-card-container">
            {order.orderRoses?.map((orderRose) => (
                <Card key={orderRose.roseId} className="order-card my-3">
                    <Row className="g-0 align-items-center">
                        <Col xs="4" sm="3" md="2">
                            <CardImg className="order-card-img" src={orderRose.rose?.image} alt={orderRose.rose?.name} />
                        </Col>
                        <Col xs="8" sm="9" md="6">
                            <CardBody>
                                <CardText className="mb-0 rose-name"><strong>{orderRose.rose?.name} Rose</strong></CardText>
                                <CardText className="mb-0 price"><strong>${orderRose.rose?.pricePerUnit} per bareroot</strong></CardText>
                            </CardBody>
                        </Col>
                        <Col xs="4" sm="3" md="2">
                            <Input
                                type="number"
                                defaultValue={orderRose.quantity}

                                className="quantity-input"
                            />
                        </Col>
                        <Col xs="4" sm="3" md="2">
                            <Button className="btn">
                                <FaTrashAlt className="trash-icon" />
                            </Button>
                        </Col>
                    </Row>
                </Card>
            ))}
        </div>
        <div className="total">
            <p>Total: ${order.total}</p>
        </div>
        <div className="total">
            <Button className="purchase-btn">Purchase</Button>
        </div>
        </div>
    );
}