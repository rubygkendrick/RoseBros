import { useState, useEffect } from "react";
import "./RoseDetails.css"
import { useNavigate, useParams } from "react-router-dom";
import { getRoseById } from "../../managers/roseManager";
import { Button, Card, CardBody, CardImg, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";
import { newOrder } from "../../managers/orderManager";

// eslint-disable-next-line react/prop-types
export default function RoseDetails({ loggedInUser }) {
    const [rose, setRose] = useState([]);
    const [quantity, setQuantity] = useState(0);
    const [modal, setModal] = useState(false);
    const { id } = useParams();

    const navigate = useNavigate();
    const toggleModal = () => setModal(!modal);

    const getAndResetRose = () => {
        getRoseById(id).then(setRose);
    };

    useEffect(() => {
        getAndResetRose();
    }, []);


    const handleQuantityChange = (event) => {

        setQuantity(parseInt(event.target.value));
    };


    const handleAddToCart = () => {
        if (quantity === 0) {
            window.alert("You must enter a quantity");
            return;
        }

        const orderRose = {
            roseId: id,
            quantity: quantity
        };

        // eslint-disable-next-line react/prop-types
        newOrder(orderRose, loggedInUser.id).then(() => {
            toggleModal();
        });
    };

    const handleContinueToCart = () => {
        toggleModal();
        // Navigate to the cart page
        navigate('/cart');
    };

    const handleKeepShopping = () => {
        toggleModal();
    };



    return (
        <>
            <div key={rose.id} className="custom-card">
                <h1>{rose.name}</h1>
                <h3>{rose.habit?.name} Rose</h3>
                <Card className="my-3 custom-card">
                    <CardImg top width="50%" src={rose.image} alt={rose.name} />
                    <CardBody className="card-padding-bottom">
                    </CardBody>
                </Card>
                <h4>{rose.description}</h4>
            </div>
            <div>
                <h5 className="price-tag">${rose.pricePerUnit} per bareroot</h5>
            </div>

            <div className="qty-input">
                <label htmlFor="quantity">Quantity:</label>
                <input
                    type="number"
                    id="quantity"
                    name="quantity"
                    min="1"
                    max="100"
                    defaultValue=""
                    onChange={handleQuantityChange}
                />
            </div>
            <div>
                <Button className="custom-btn" onClick={handleAddToCart} style={{ marginTop: '40px' }}>
                    Add To Cart
                </Button>

                <Modal isOpen={modal} toggle={toggleModal} className="custom-modal">
                    <ModalHeader toggle={toggleModal} className="custom-modal-header">Added to Cart</ModalHeader>
                    <ModalBody className="custom-modal-body">
                        Would you like to continue to the cart or keep shopping?
                    </ModalBody>
                    <ModalFooter className="custom-modal-footer">
                        <Button className="custom-modal-button" onClick={handleContinueToCart}>Go to Cart</Button>{' '}
                        <Button className="custom-modal-button-secondary" onClick={handleKeepShopping}>Keep Shopping</Button>
                    </ModalFooter>
                </Modal>
            </div>
        </>
    );

}