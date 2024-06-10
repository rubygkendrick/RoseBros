import { useState, useEffect } from "react";
import "./RoseDetails.css"


import { useNavigate, useParams } from "react-router-dom";
import { getRoseById } from "../../managers/roseManager";
import { Button, Card, CardBody, CardImg, CardText, CardTitle } from "reactstrap";



export default function RoseDetails() {
    const [rose, setRose] = useState([]);
    const { id } = useParams();


    const navigate = useNavigate();

    const getAndResetRose = () => {
        getRoseById(id).then(setRose);
    };


    useEffect(() => {
        getAndResetRose();

    }, []);



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
                <label>Quantity:</label>
                <input type="number" id="quantity" name="quantity" min="1" max="100" />
            </div>
            <Button className="custom-btn"
                style={{ marginTop: '40px', marginBottom: '200px' }}>
                Add To Cart</Button>

        </>
    );

}