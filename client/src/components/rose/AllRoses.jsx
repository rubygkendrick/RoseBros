import { useState, useEffect } from "react";
import "./AllRoses.css"

import { Link } from "react-router-dom";
import { Card, CardBody, CardText, CardImg, Row, Col } from "reactstrap";
import { getRoses } from "../../managers/roseManager";




export default function AllRoses() {
    const [roses, setRoses] = useState([]);


    const getAndResetAllRoses = () => {
        getRoses().then(setRoses);
    };



    useEffect(() => {
        getAndResetAllRoses();
    }, []);





    return (
        <>
            <h1>RoseBros</h1>
            <Row>
                {roses.map((rose) => {
                    return (
                        <Col sm="12" md="6" lg="4" key={rose.id}>
                            <Card className="my-3">
                                <CardImg top width="100%"
                                    src={`${rose.image}?${new Date().getTime()}`} alt={rose.name} />
                                <CardBody className="card-padding-bottom">
                                    <Link to={`/rose/${rose.id}`} className="rose-title">
                                        <CardText tag="h3">{rose.name}</CardText>
                                    </Link>
                                    <CardText>{rose.habit?.name} Rose</CardText>
                                    {rose.outOfStock ?
                                        <CardText className="out-of-stock">Out of Stock</CardText> :
                                        <CardText>${rose.pricePerUnit} per bareroot</CardText>}
                                </CardBody>
                            </Card>
                        </Col>
                    );
                })}
            </Row>
        </>
    );
}