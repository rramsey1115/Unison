import { useState } from "react";
import { NavLink as RRNavLink, useNavigate } from "react-router-dom";
import { Collapse, Nav, NavLink, NavItem, Navbar, NavbarBrand, NavbarToggler } from "reactstrap";
import { logout } from "../../Managers/authManger";
import icon from "../../images/icon.png"
import "./NavBar.css";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
const [open, setOpen] = useState(false);

const navigate = useNavigate();

const toggleNavbar = () => setOpen(!open);

const closeNavbar = () => setOpen(false);

    return (
        <Navbar color="info" fixed="true" expand="md">
            
            <NavbarBrand className="mr-auto" tag={RRNavLink} to="/" onClick={closeNavbar}>
                <div id="nav-title">
                    <img id="navbar-icon" src={icon} alt="icon" style={{height:42, marginRight:12, padding:0}}/>
                    <h3>UNISON</h3>
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
                                <NavLink tag={RRNavLink} to="/students" onClick={closeNavbar}>
                                    My Students
                                </NavLink>
                            </NavItem>
            
                            <NavItem>
                                <NavLink tag={RRNavLink} to="/browse/category" onClick={closeNavbar}>
                                    Browse
                                </NavLink>
                            </NavItem>
                        </Nav>
                        <button
                            className="nav-btn"
                            onClick={(e) => {
                                e.preventDefault();
                                setOpen(false);
                                logout().then(() => {
                                    setLoggedInUser(null);
                                    setOpen(false);
                                    navigate('/');
                                });
                            }}
                        >
                        Logout
                        </button>
                    </Collapse>
                </>
                :
                    <>
                        <NavbarToggler onClick={toggleNavbar} />
                        <Collapse isOpen={open} navbar>
                            <Nav navbar>
                                <NavItem>
                                    <NavLink tag={RRNavLink} to="/session" onClick={closeNavbar}>
                                        Sessions
                                    </NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={RRNavLink} to={`profile/${loggedInUser.id}`} onClick={closeNavbar}>
                                        Profile
                                    </NavLink>
                                </NavItem> 
                                <NavItem>
                                    <NavLink tag={RRNavLink} to={`assignments/${loggedInUser.id}`} onClick={closeNavbar}>
                                        Assignments
                                    </NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={RRNavLink} to="/browse/category" onClick={closeNavbar}>
                                        Browse
                                    </NavLink>
                                </NavItem>
                            </Nav>
                            <button style={{alignSelf:"right"}}
                                className="nav-btn"
                                size="md"
                                onClick={(e) => {
                                    e.preventDefault();
                                    setOpen(false);
                                    logout().then(() => {
                                        setLoggedInUser(null);
                                        setOpen(false);
                                        navigate('/');
                                    });
                                }}
                            >
                            Logout
                            </button>
                        </Collapse>
                    </>}
                </>
                :
                <Nav navbar>
                    <NavItem>
                        <NavLink tag={RRNavLink} to="/login" onClick={closeNavbar}>
                            <button className="nav-btn" size="md" color="secondary">Login</button>
                        </NavLink>
                    </NavItem>
                </Nav>
            }
       </Navbar>
    );
}