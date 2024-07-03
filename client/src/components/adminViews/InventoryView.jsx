import { useState, useEffect } from "react";
import "./InventoryView.css"
import { Link, useNavigate } from "react-router-dom";
import { FaTrashAlt } from 'react-icons/fa';
import { Button, Card, CardBody, CardImg, CardText, Col, Modal, ModalBody, ModalFooter, ModalHeader, Row } from "reactstrap";
import { deleteRose, getRoses, updateStockStatus } from "../../managers/roseManager";



// eslint-disable-next-line react/prop-types
export default function InventoryView({ loggedInUser }) {
    const [inventory, setInventory] = useState([]);
    const [refresh, setRefresh] = useState(false);
    const [modal, setModal] = useState(false);
    const [roseIdToDelete, setRoseIdToDelete] = useState(null);

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

    const handleDeleteClick = (roseId) => {
        setRoseIdToDelete(roseId);
        toggleModal();
    };

    const handleDeleteConfirm = () => {
        deleteRose(roseIdToDelete).then(() => {
            setRefresh(!refresh);
            toggleModal();
        });

    };
    const handleCancelClick = () => {
        toggleModal();
    }

    useEffect(() => {
        getAndResetInventory();
    }, [refresh]);

    return (
        <>
            <Button className="btn add-btn"
                onClick={handleAddClick}
            >Add Inventory</Button>
            <div className="order-card-container" >
                {inventory.map((rose) => (
                    <div key={rose.id}><Card key={rose.id} className="order-card my-3">
                        <Row className="g-0 align-items-center">
                            <Col xs="4" sm="3" md="2">
                                <CardImg className="order-card-img" src={rose.image} alt={rose.name} />
                            </Col>
                            <Col xs="12" sm="9" md="6">
                                <CardBody className="text-center">
                                    <div className="card-text-container">
                                        <Link to={`/add-inventory/${rose.id}`} className="rose-title">
                                            <CardText className="mb-0 rose-name">
                                                <strong>{rose.name}</strong>
                                            </CardText>
                                        </Link>

                                        <CardText className="mb-0" id="price">
                                            <strong>${rose.pricePerUnit} per bareroot</strong>
                                        </CardText>
                                    </div>
                                </CardBody>
                            </Col>
                            <Col xs="4" sm="3" md="2">
                                {rose.outOfStock ?
                                    <Button value={rose.id}
                                        onClick={handleUpdateStockConfirm}
                                        className="in-stock-btn">Back In Stock</Button> :
                                    <Button value={rose.id}
                                        onClick={handleUpdateStockConfirm}>Out Of Stock</Button>}
                            </Col>
                            <Col xs="4" sm="3" md="2">
                                <Button className="btn" onClick={() => handleDeleteClick(rose.id)}>
                                    <FaTrashAlt className="trash-icon" />
                                </Button>
                            </Col>
                        </Row>
                    </Card>
                        <Modal isOpen={modal} toggle={toggleModal} className="custom-modal">
                            <ModalHeader toggle={toggleModal} className="custom-modal-header">Confirmation:</ModalHeader>
                            <ModalBody className="custom-modal-body">
                                Are you sure you want to delete this rose?
                            </ModalBody>
                            <ModalFooter className="custom-modal-footer">
                                <Button className="custom-modal-button"
                                    onClick={handleCancelClick}>Cancel</Button>{' '}
                                <Button className="custom-modal-button-secondary"
                                    value={rose.id} onClick={handleDeleteConfirm}>Delete</Button>
                            </ModalFooter>
                        </Modal></div>

                ))}

            </div>
        </>
    );
}