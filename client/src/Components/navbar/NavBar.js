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
import { logout } from "../../Managers/authManger";
import icon from "../../images/icon.png"
import "../../index.css";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
const [open, setOpen] = useState(false);

const toggleNavbar = () => setOpen(!open);

    return (
        <Navbar color="info" fixed="true" expand="sm">
            
            <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
                <div id="nav-title">
                    <img id="navbar-icon" src={icon} alt="icon" style={{height:42, marginRight:12, padding:0}}/>
                    <h4>UNISON</h4>
                </div>
            </NavbarBrand>

            {loggedInUser?.firstName ?
            <>
                {loggedInUser?.roles?.includes("Teacher") ?
                <>
                    <NavbarToggler onClick={toggleNavbar} />
                    <Collapse isOpen={open} navbar>
                        <Nav navbar>
                            <NavItem>
                                <NavLink tag={RRNavLink} to="/students">
                                    My Students
                                </NavLink>
                            </NavItem>
            
                            <NavItem>
                                <NavLink tag={RRNavLink} to="">
                                    Assignments
                                </NavLink>
                            </NavItem>
            
                            <NavItem>
                                <NavLink tag={RRNavLink} to="/browse/category">
                                    Browse
                                </NavLink>
                            </NavItem>
                            <Button
                                color="secondary"
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
                        </Nav>
                    </Collapse>
                </>
                :
                    <>
                        <NavbarToggler onClick={toggleNavbar} />
                        <Collapse isOpen={open} navbar>
                            <Nav navbar>
                                <NavItem>
                                    <NavLink tag={RRNavLink} to="/session">
                                        Sessions
                                    </NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={RRNavLink} to="">
                                        Stats
                                    </NavLink>
                                </NavItem> 
                                <NavItem>
                                    <NavLink tag={RRNavLink} to="/favorite">
                                        Favorites
                                    </NavLink>
                                </NavItem> 
                                <NavItem>
                                    <NavLink tag={RRNavLink} to="">
                                        Assignments
                                    </NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={RRNavLink} to="/browse/category">
                                        Browse
                                    </NavLink>
                                </NavItem>
                                <Button
                                    color="secondary"
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
                            </Nav>
                        </Collapse>
                    </>}
                </>
                :
                <Nav navbar>
                    <NavItem>
                        <NavLink tag={RRNavLink} to="/login">
                            <Button color="secondary">Login</Button>
                        </NavLink>
                    </NavItem>
                </Nav>
            }
       </Navbar>
    );
}