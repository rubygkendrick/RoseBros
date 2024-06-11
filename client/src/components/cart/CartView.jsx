/* eslint-disable react/prop-types */
import { useState, useEffect } from "react";
import "./CartView.css"
import { useNavigate} from "react-router-dom";

import { Card, CardBody, CardImg, CardText, Col} from "reactstrap";



// eslint-disable-next-line react/prop-types
export default function CartView({ loggedInUser }) {
    const [order, setOrder] = useState([]);
    const [modal, setModal] = useState(false);


    const navigate = useNavigate();
    const toggleModal = () => setModal(!modal);

    const getAndResetOrder = () => {
        getOrderByUserId(loggedInUser.id).then(setOrder);
    };

    useEffect(() => {
        getAndResetOrder();
    }, []);


    return (
        <>
            {order.orderRoses.map((orderRose) => (
                    <Col sm="12" md="6" lg="4" key={rose.id}>
                        <Card className="my-3">
                            <CardImg top width="100%" src={orderRose.rose?.image} alt={orderRose.rose?.name} />
                            <CardBody className="card-padding-bottom">
                                <CardText>{orderRose.rose?.name} Rose</CardText>
                                <CardText>${orderRose.rose?.quantity} per bareroot</CardText>
                            </CardBody>
                        </Card>
                    </Col>
                ))}
        </>
    );

}