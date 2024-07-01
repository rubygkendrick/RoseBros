import { useState, useEffect } from "react";
import "./AllRoses.css"
import { Link } from "react-router-dom";
import { Card, CardBody, CardText, CardImg, Row, Col, Label, Input } from "reactstrap";
import { getRoses } from "../../managers/roseManager";
import { getColors } from "../../managers/colorManager";


export default function AllRoses() {
    const [roses, setRoses] = useState([]);
    const [colors, setColors] = useState([]);
    const [filteredRoses, setFilteredRoses] = useState([]);
    const [colorId, setColorId] = useState(0);

    const getAndResetAllRoses = () => {
        getRoses().then(setRoses);
    };

    const getAndSetColors = () => {
        getColors().then(setColors);
    };

    useEffect(() => {
        getAndResetAllRoses();
        getAndSetColors();
    }, []);


    const handleColorSelect = (event) => {
        const selectedColorId = event.target.value;
        setFilteredRoses(roses.filter(r => r.colorId == selectedColorId));
    }


    useEffect(() => {
        setRoses(filteredRoses)
    }, []);

    const rosesToDisplay = filteredRoses.length > 0 ? filteredRoses : roses;


    return (
        <>
            <h1>RoseBros</h1>

            <Input
                type="select"
                id="colorSearch"
                className="input-field"
                defaultValue=""
                onChange={handleColorSelect}
            >
                <option value="">select a color</option>
                {colors.map((color) => (
                    <option key={color.id} value={color.id}>
                        {color.name}
                    </option>
                ))}
            </Input>
            <Row>
                {rosesToDisplay.map((rose) => {
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