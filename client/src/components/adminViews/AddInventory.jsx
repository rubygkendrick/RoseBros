import { useEffect, useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { useNavigate } from "react-router-dom";
import "./AddInventory.css";

import { getColors } from "../../managers/colorManager";
import { getHabits } from "../../managers/habitManager";


export default function AddInventory({ loggedInUser }) {
    const [roseName, setRoseName] = useState("");
    const [description, setDescription] = useState("");
    const [image, setRoseImage] = useState("");
    const [colorId, setColorId] = useState("");
    const [habitId, setHabitId] = useState("")
    const [pricePerUnit, setPricePerUnit] = useState(0);
    const [errors, setErrors] = useState(false);
    const [colors, setColors] = useState([]);
    const [habits, setHabits] = useState([]);

    const navigate = useNavigate();

    const getAndSetColors = () => {
        getColors().then(setColors);
    }

    const getAndSetHabits = () => {
        getHabits().then(setHabits);
    }

    useEffect(() => {
        getAndSetColors();
        getAndSetHabits();
    }, []);

    const handleSubmit = (e) => {
        e.preventDefault();
        const newRose = {
            name: roseName,
            colorId: parseInt(colorId),
            habitId: parseInt(habitId),
            description: description,
            image: image,
            pricePerUnit: parseFloat(pricePerUnit)
        };

        // addRose(newRose).then((res) => {
        //     if (res.errors) {
        //         setErrors(res.errors);
        //     } else {
        //         navigate("/");
        //     }
        // })
    };

    return (
        <>
            <div style={{ color: "red" }}>
                {errors && Object.keys(errors).map((key) => (
                    <p key={key}>
                        {key}: {errors[key].join(",")}
                    </p>
                ))}
            </div>
            <Form className="form-body">
                <FormGroup>
                    <Label>Rose Name</Label>
                    <Input
                        className="input-field"
                        type="text"
                        defaultValue=""
                        onChange={(e) => {
                            setRoseName(e.target.value);
                        }}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="colorSelect">Color</Label>
                    <Input
                        type="select"
                        id="colorSelect"
                        className="input-field"
                        defaultValue=""
                        onChange={(e) => setColorId(e.target.value)}
                    >
                        <option value="">Select a color</option>
                        {colors.map((color) => (
                            <option key={color.id} value={color.id}>
                                {color.name}
                            </option>
                        ))}
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Label for="habitSelect">Habit</Label>
                    <Input
                        type="select"
                        id="habitSelect"
                        className="input-field"
                        value={habitId}
                        onChange={(e) => setHabitId(e.target.value)}
                    >
                        <option value="">Select a habit</option>
                        {habits.map((habit) => (
                            <option key={habit.id} value={habit.id}>
                                {habit.name}
                            </option>
                        ))}
                    </Input>
                </FormGroup>
                <FormGroup>
                    <Label for="description">Description</Label>
                    <Input
                        type="textarea"
                        className="input-field"
                        id="description"
                        rows="6" 
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="image">Image URL</Label>
                    <Input
                        type="text"
                        className="input-field"
                        id="image"
                        onChange={(e) => setRoseImage(e.target.value)}
                    />
                </FormGroup>
                <FormGroup>
                    <Label for="image">Price Per Bareroot</Label>
                    <Input
                        type="text"
                        className="input-field"
                        id="pricePerUnit"
                        onChange={(e) => setPricePerUnit(e.target.value)}
                    />
                </FormGroup>

                <Button onClick={handleSubmit} className="custom-btn submit">
                    Submit
                </Button>
            </Form>


        </>
    );
}