import { useEffect, useState } from "react";
import { register } from "../../Managers/authManger";
import { Link, useNavigate } from "react-router-dom";
import { Button, FormFeedback, FormGroup, Input, InputGroup, InputGroupText, Label } from "reactstrap";
import { getUsersWithRoles } from "../../Managers/profileManager";
import { MdAlternateEmail } from "react-icons/md";
import { FaUserAlt } from "react-icons/fa";
import { FaGlobe } from "react-icons/fa";
import { FaMapLocationDot } from "react-icons/fa6";
import { RiLockPasswordFill } from "react-icons/ri";



export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [address, setAddress] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [teacherId, setTeacherId] = useState(null);
  const [signUpWithTeacher, setSignUpWithTeacher] = useState(false);

  const [teachers, setTeachers] = useState([]);

  const [passwordMismatch, setPasswordMismatch] = useState();
  const [registrationFailure, setRegistrationFailure] = useState(false);

  useEffect(() => { getAndSetTeachers() }, [])

  const navigate = useNavigate();

  const getAndSetTeachers = () => {
    getUsersWithRoles().then(data => {
      var filteredArr = data.filter(d => d.roles[0] == "Teacher");
      setTeachers(filteredArr);
    });
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) 
    {
      setPasswordMismatch(true);
    } 
    else 
    {
      var newUser = {
        firstName,
        lastName,
        userName,
        email,
        address,
        password
      }
      if(teacherId) {
        newUser = {
          firstName,
          lastName,
          userName,
          email,
          address,
          password,
          teacherId
        }
      }

      register(newUser).then((user) => {
        if (user) {
          setLoggedInUser(user);
          navigate("/");
        } else {
          setRegistrationFailure(true);
        }
      });
    }
  };


  
  return (
    <div className="login-container">
      <div className="login-header">
        <h2>Sign Up</h2>
      </div>

      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <FaUserAlt />
          </InputGroupText>
            <Input
              type="text"
              value={firstName}
              placeholder="First Name"
              onChange={(e) => {
                setFirstName(e.target.value);
              }}
            />
        </InputGroup>
      </FormGroup>

      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <FaUserAlt />
          </InputGroupText>
            <Input
              type="text"
              value={lastName}
              placeholder="Last Name"
              onChange={(e) => {
                setLastName(e.target.value);
              }}
            />
        </InputGroup>
      </FormGroup>

      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <FaMapLocationDot />
          </InputGroupText>
          <Input
            type="text"
            value={address}
            placeholder="Address"
            onChange={(e) => {
              setAddress(e.target.value);
            }}
          />
        </InputGroup>
      </FormGroup>

      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <FaGlobe />
          </InputGroupText>
          <Input
            type="text"
            value={userName}
            placeholder="Username"
            onChange={(e) => {
              setUserName(e.target.value);
            }}
          />
        </InputGroup>
      </FormGroup>

      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <MdAlternateEmail />
          </InputGroupText>
          <Input
            type="email"
            value={email}
            placeholder="Email"
            onChange={(e) => {
              setEmail(e.target.value);
            }}
          />
        </InputGroup>
      </FormGroup>


      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <RiLockPasswordFill />
          </InputGroupText>
          <Input
            invalid={passwordMismatch}
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => {
              setPasswordMismatch(false);
              setPassword(e.target.value);
            }}
          />
        </InputGroup>
      </FormGroup>
      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <RiLockPasswordFill />
          </InputGroupText>
          <Input
          invalid={passwordMismatch}
          type="password"
          placeholder="Confirm"
          value={confirmPassword}
          onChange={(e) => {
            setPasswordMismatch(false);
            setConfirmPassword(e.target.value);
          }}
        />
        </InputGroup>
        <FormFeedback>Passwords do not match!</FormFeedback>
      </FormGroup>

      Sign Up With Teacher?
      <FormGroup className="radio-div">
          <div style={{margin:10}}>
            <Input 
              style={{padding:6}}
              required
              id="teacher-checkbox-yes" 
              className="radio-input" 
              type="radio"
              name="teacher"
              onClick={(e) => setSignUpWithTeacher(true)}
            /> Yes
          </div>
          <div style={{margin:10}}>
            <Input 
              required
              defaultChecked
              id="teacher-checkbox-no" 
              className="radio-input" 
              type="radio"
              name="teacher"
              onClick={(e) => setSignUpWithTeacher(false)}
            /> No
          </div>
      </FormGroup>
      {signUpWithTeacher == false ? null : 
      <FormGroup>
        <select
          required
          name="teacher"
          id="teacher-dropdown"
          className="dropdown"
          onChange={(e) => {
            setTeacherId(e.target.value*1);
          }}>
          <option value={0} name="teacher">Select Teacher</option>
          {teachers.map(t => {
            return (
              <option key={t.id} value={t.id} name="teacher">
                {`${t.firstName} ${t.lastName}`}
              </option>
            )
          })}
        </select>
      </FormGroup>}

      <p style={{ color: "red" }} hidden={!registrationFailure}>
        Registration Failure
      </p>

      <button
        className="animated-btn"
        color="primary"
        onClick={handleSubmit}
        disabled={passwordMismatch}
      >
        Register
      </button>

      <p>
        Already signed up? <Link to="/login">Log in</Link>
      </p>

    </div>
  );
}
