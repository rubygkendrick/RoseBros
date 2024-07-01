import { useState, useEffect } from "react";
import "./AllRoses.css";
import { Link } from "react-router-dom";
import { Card, CardBody, CardText, CardImg, Row, Col, Input } from "reactstrap";
import { getRoses } from "../../managers/roseManager";
import { getColors } from "../../managers/colorManager";
import { getHabits } from "../../managers/habitManager";

export default function AllRoses() {
    const [roses, setRoses] = useState([]);
    const [colors, setColors] = useState([]);
    const [habits, setHabits] = useState([]);
    const [filteredRoses, setFilteredRoses] = useState([]);
    const [selectedColorId, setSelectedColorId] = useState("");
    const [selectedHabitId, setSelectedHabitId] = useState("");

    useEffect(() => {
        getRoses().then(setRoses);
        getColors().then(setColors);
        getHabits().then(setHabits);
    }, []);

    useEffect(() => {
        let filtered = roses;
        if (selectedColorId) {
            filtered = filtered.filter(r => r.colorId == selectedColorId);
        }
        if (selectedHabitId) {
            filtered = filtered.filter(r => r.habitId == selectedHabitId);
        }
        setFilteredRoses(filtered);
    }, [selectedColorId, selectedHabitId, roses]);

    const handleColorSelect = (event) => {
        setSelectedColorId(event.target.value);
    };

    const handleHabitSelect = (event) => {
        setSelectedHabitId(event.target.value);
    };

    const rosesToDisplay = filteredRoses.length > 0 ? filteredRoses :
        (selectedColorId || selectedHabitId) ? [] : roses;

    return (
        <>
            <h1>RoseBros</h1>
            <div className="searchBars">
                <Input
                    type="select"
                    id="colorSearch"
                    className="input-field"
                    defaultValue=""
                    onChange={handleColorSelect}
                >
                    <option value="">Select a color</option>
                    {colors.map((color) => (
                        <option key={color.id} value={color.id}>
                            {color.name}
                        </option>
                    ))}
                </Input>
                <Input
                    type="select"
                    id="colorSearch"
                    className="input-field"
                    defaultValue=""
                    onChange={handleHabitSelect}
                >
                    <option value="">Select a habit</option>
                    {habits.map((habit) => (
                        <option key={habit.id} value={habit.id}>
                            {habit.name}
                        </option>
                    ))}
                </Input>
            </div>
            <Row>
                {rosesToDisplay.length > 0 ? rosesToDisplay.map((rose) => (
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
                )) : <p>No roses found for the selected filters.</p>}
            </Row>
        </>
    );
}
