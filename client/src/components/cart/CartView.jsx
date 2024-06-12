/* eslint-disable react/prop-types */
import { useState, useEffect } from "react";
import "./CartView.css"
import { useNavigate } from "react-router-dom";
import { FaTrashAlt } from 'react-icons/fa';
import { Button, Card, CardBody, CardImg, CardText, Col, Input, Row } from "reactstrap";
import { getActiveOrderByUserId } from "../../managers/orderManager";
import { updateQuantity } from "../../managers/orderRoseManager";



// eslint-disable-next-line react/prop-types
export default function CartView({ loggedInUser }) {
    const [order, setOrder] = useState([]);
    const [refresh , setRefresh] = useState(false);
    const [modal, setModal] = useState(false);
    const [orderEmpty, setOrderEmpty] = useState(false);


    const navigate = useNavigate();
    const toggleModal = () => setModal(!modal);

    const getAndResetOrder = () => {
        getActiveOrderByUserId(loggedInUser.id).then((res) => setOrder(res))
            .catch((error) => {
                if (error) {
                    setOrderEmpty(true);
                }
            });
    };
    
    const handleKeepShoppingClick = () => {
        navigate("/")
    }
 

    const handleQuantityChange = (event) => {
       const newQty = parseInt(event.target.value)
        updateQuantity(newQty, parseInt(event.target.id) , loggedInUser.id).then(() => {setRefresh(!refresh)})
    };

    useEffect(() => {
        getAndResetOrder();
    }, [refresh]);

    return (
        <div>
            {orderEmpty === true ? (
                <>
                <p className="empty-cart">Uh oh! Your cart is empty</p>
                <Button className="purchase-btn" onClick={handleKeepShoppingClick}>Keep Shopping</Button>
                </>
            ) : (
                <>
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
                                            id = {orderRose.roseId}
                                            onChange={handleQuantityChange}
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
                </>
            )}
        </div>
    );
}