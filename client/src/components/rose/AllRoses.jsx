import { useState, useEffect } from "react";

import { Link, useNavigate } from "react-router-dom";
import { Card, CardBody, CardTitle, CardText, CardImg } from "reactstrap";
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
            {roses.map((rose) => (
                <Card key={rose.id} className="my-3">
                    <CardImg top width="100%" src={rose.image} alt={rose.name} />
                    <CardBody>
                        <CardTitle tag="h2">{rose.name}</CardTitle>
                        <CardText>{rose.description}</CardText>
                        {/* You can add more details or buttons here if needed */}
                    </CardBody>
                </Card>
            ))}
        </>
    );
}