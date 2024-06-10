import { useState, useEffect } from "react";

import { Link, useNavigate } from "react-router-dom";
import { Card, CardBody, CardTitle, CardText, CardImg, Row, Col } from "reactstrap";
import { getRoses } from "../../managers/roseManager";


export default function AllRoses({ loggedInUser, setLoggedInUser, roles }) {
    const [roses, setRoses] = useState([]);
    const navigate = useNavigate();

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
                {roses.map((rose) => (
                    <Col sm="12" md="6" lg="4" key={rose.id}>
                        <Card className="my-3">
                            <CardImg top width="100%" src={rose.image} alt={rose.name} />
                            <CardBody className="card-padding-bottom">
                                <Link to={`/rose/${rose.id}`}><CardTitle tag="h2">{rose.name}</CardTitle></Link>
                                <CardText>{rose.habit?.name} Rose</CardText>
                                <CardText>${rose.pricePerUnit} per bareroot</CardText>
                            </CardBody>
                        </Card>
                    </Col>
                ))}
            </Row>
        </>
    );
}