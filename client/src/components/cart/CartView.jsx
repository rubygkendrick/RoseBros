/* eslint-disable react/prop-types */
import { useState, useEffect } from "react";
import "./CartView.css"
import { useNavigate } from "react-router-dom";
import { FaTrashAlt } from 'react-icons/fa';
import { Button, Card, CardBody, CardImg, CardText, Col, Input, Modal, ModalBody, ModalFooter, ModalHeader, Row } from "reactstrap";
import { completeOrder, getActiveOrderByUserId } from "../../managers/orderManager";
import { deleteOrderRose, updateQuantity } from "../../managers/orderRoseManager";



// eslint-disable-next-line react/prop-types
export default function CartView({ loggedInUser }) {
    const [order, setOrder] = useState([]);
    const [refresh, setRefresh] = useState(false);
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

    const handleCancelClick = () => {
        toggleModal();
    }


    const handleQuantityChange = (event) => {
        const newQty = parseInt(event.target.value)
        if (newQty <= 0 || isNaN(newQty)) {
            window.alert("You must enter a valid quantity (a non-negative number).");
            return;
        }
        updateQuantity(newQty, parseInt(event.target.id), loggedInUser.id).then(() => { setRefresh(!refresh) })
    };

    const handleOrderRoseDelete = (roseId) => {

        deleteOrderRose(roseId, order.id).then(() => {
            setRefresh(!refresh);
        });
    }

    const handlePurchaseClick = () => {
        toggleModal();
    }

    const handlePurchaseConfirm = (orderId) => {
        completeOrder(orderId).then(() => {
            sessionStorage.setItem('recentPurchase', 'true');
            navigate("/orderConfirmation")
        })
    };

    const handleKeepShoppingClick = () => {
        navigate('/')
    }


    useEffect(() => {
        getAndResetOrder();
    }, [refresh]);

    return (
        <div>
            {orderEmpty === true ? (
                <>
                    <p className="empty-cart">Uh oh! Your cart is empty</p>
                    <Button className="purchase-btn"
                        onClick={handleKeepShoppingClick}>Start Shopping</Button>
                </>
            ) : (
                <>
                    <div className="order-card-container">
                        {order.orderRoses?.map((orderRose) => (
                            <Card key={orderRose.roseId} className="order-card my-3">
                                <Row className="g-0 align-items-center">
                                    <Col xs="4" sm="3" md="2">
                                        <CardImg className="order-card-img"
                                            src={orderRose.rose?.image} alt={orderRose.rose?.name} />
                                    </Col>
                                    <Col xs="12" sm="9" md="6">
                                        <CardBody className="text-center">
                                            <div className="card-text-container">
                                                <CardText className="mb-0 rose-name">
                                                    <strong>{orderRose.rose?.name}</strong>
                                                </CardText>
                                                <CardText className="mb-0" id="price">
                                                    <strong>${orderRose.rose?.pricePerUnit} per bareroot</strong>
                                                </CardText>
                                            </div>
                                        </CardBody>
                                    </Col>
                                    <Col xs="4" sm="3" md="2">
                                        <Input
                                            type="number"
                                            min="1"
                                            max="100"
                                            defaultValue={orderRose.quantity}
                                            id={orderRose.roseId}
                                            onChange={handleQuantityChange}
                                            className="quantity-input"
                                        />
                                    </Col>
                                    <Col xs="4" sm="3" md="2">
                                        <Button className="btn"
                                            onClick={() => handleOrderRoseDelete(orderRose.roseId)}>
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
                        <Button className="purchase-btn" onClick={handlePurchaseClick}>Purchase</Button>
                    </div>

                    <Modal isOpen={modal} toggle={toggleModal}
                        className="custom-modal">
                        <ModalHeader toggle={toggleModal}
                            className="custom-modal-header">Confirmation:</ModalHeader>
                        <ModalBody className="custom-modal-body">
                            Would you like to continue with this purchase?
                        </ModalBody>
                        <ModalFooter className="custom-modal-footer">
                            <Button className="custom-modal-button"
                                onClick={() => handlePurchaseConfirm(order.id)}>Complete Purchase</Button>{' '}
                            <Button className="custom-modal-button-secondary"
                                onClick={handleCancelClick}>Cancel</Button>
                        </ModalFooter>
                    </Modal>
                </>
            )}
        </div>
    );
}