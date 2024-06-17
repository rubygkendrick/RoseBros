import { useState, useEffect } from "react";
import "./InventoryView.css"
import { useNavigate } from "react-router-dom";
import { FaTrashAlt } from 'react-icons/fa';
import { Button, Card, CardBody, CardImg, CardText, Col,  Modal, ModalBody, ModalFooter, ModalHeader, Row } from "reactstrap";
import { getRoses, updateStockStatus } from "../../managers/roseManager";



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

   const handleAddClick = () => {
    navigate("/add-inventory")
   }

   const handleUpdateStockConfirm = (event) => {
    const roseId = parseInt(event.target.value)
    updateStockStatus(roseId).then(() => setRefresh(!refresh))
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
                                        {rose.outOfStock ? 
                                        <Button value ={rose.id} onClick={handleUpdateStockConfirm} className="in-stock-btn">Back In Stock</Button> : 
                                        <Button value ={rose.id} onClick={handleUpdateStockConfirm}>Out Of Stock</Button> }
                                       
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