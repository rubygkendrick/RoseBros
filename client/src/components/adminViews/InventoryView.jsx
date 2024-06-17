import { useState, useEffect } from "react";
import "./InventoryView.css"
import { useNavigate } from "react-router-dom";
import { FaTrashAlt } from 'react-icons/fa';
import { Button, Card, CardBody, CardImg, CardText, Col, Input, Modal, ModalBody, ModalFooter, ModalHeader, Row } from "reactstrap";
import { getRoses } from "../../managers/roseManager";



// eslint-disable-next-line react/prop-types
export default function InventoryView({ loggedInUser }) {
    const [inventory, setInventory] = useState([]);
    const [refresh, setRefresh] = useState(false);
    const [modal, setModal] = useState(false);

    const navigate = useNavigate();
    const toggleModal = () => setModal(!modal);

    const getAndResetInventory = () => {
        getRoses().then((res) => setInventory(res))
           
    };

   // const handleCancelClick = () => {
   //     toggleModal();
   // }
//
//
//
//
   // const handleOrderRoseDelete = (roseId) => {
//
   //     deleteRose(roseId).then(() => {
   //         setRefresh(!refresh);
   //     });
   // }
   const handleAddClick = () => {
    navigate("/add-inventory")
   }


    useEffect(() => {
        getAndResetInventory();
    }, [refresh]);

    return (
                   <>
                   <Button className="btn add-btn"
                   onClick={handleAddClick}
                   >Add Inventory</Button>
                    <div className="order-card-container">
                        {inventory.map((rose) => (
                            <Card key={rose.id} className="order-card my-3">
                                <Row className="g-0 align-items-center">
                                    <Col xs="4" sm="3" md="2">
                                        <CardImg className="order-card-img" src={rose.image} alt={rose.name} />
                                    </Col>
                                    <Col xs="8" sm="9" md="6">
                                        <CardBody>
                                            <CardText className="mb-0 rose-name"><strong>{rose.name} Rose</strong></CardText>
                                            <CardText className="mb-0 price"><strong>${rose.pricePerUnit} per bareroot</strong></CardText>
                                        </CardBody>
                                    </Col>
                                    <Col xs="4" sm="3" md="2">
                                        <Input
                                            type="number"
                                            min="1"
                                            max="100"
                                            defaultValue={rose.id}
                                            id={rose.id}
                                           
                                            className="quantity-input"
                                        />
                                    </Col>
                                    <Col xs="4" sm="3" md="2">
                                        <Button className="btn" >
                                            <FaTrashAlt className="trash-icon" />
                                        </Button>
                                    </Col>
                                </Row>
                            </Card>
                        ))}
                    </div>
                </>
    );
}