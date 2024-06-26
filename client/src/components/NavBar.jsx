/* eslint-disable react/prop-types */
import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
    Button,
    Collapse,
    Nav,
    NavLink,
    NavItem,
    Navbar,
    NavbarBrand,
    NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import "./NavBar.css"


export default function NavBar({ loggedInUser, setLoggedInUser }) {
    const [open, setOpen] = useState(false);

    const toggleNavbar = () => setOpen(!open);

    return (
        <div>
            <Navbar className="navbar solid-navbar" light fixed="top" expand="lg">
                <NavbarBrand className="nav-item" style={{ fontSize: '1.5rem' }} tag={RRNavLink} to="/">
                    RoseBros
                </NavbarBrand>

                {loggedInUser ? (
                    <>
                        <NavbarToggler onClick={toggleNavbar} />
                        <Collapse isOpen={open} navbar>
                            <Nav navbar></Nav>
                        </Collapse>
                        {loggedInUser.roles.includes("Admin") && (
                                <>
                                <NavLink className="nav-item" tag={RRNavLink} to="/inventory">
                                    Inventory
                                </NavLink>
                                <NavLink className="nav-item" tag={RRNavLink} to="/orders">
                                    Orders
                                </NavLink>
                                </>                         
                        )}
                        <NavLink className="nav-item" tag={RRNavLink} to="/cart">
                            Cart
                        </NavLink>

                        <NavLink className="nav-item" tag={RRNavLink} to={`/userProfile`}>
                            Profile
                        </NavLink>

                        <Button
                            className="custom-btn-nav"

                            onClick={(e) => {
                                e.preventDefault();
                                setOpen(false);
                                logout().then(() => {
                                    setLoggedInUser(null);
                                    setOpen(false);
                                });
                            }}
                        >
                            Logout
                        </Button>
                    </>


                ) : (
                    <Nav navbar>
                        <NavItem>
                            <NavLink tag={RRNavLink} to="/login">
                                <Button className="custom-btn-nav">Login</Button>
                            </NavLink>
                        </NavItem>
                    </Nav>
                )}

            </Navbar>
        </div>
    );
}