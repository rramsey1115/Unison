import { useEffect, useState } from "react";
import { register } from "../../Managers/authManger";
import { Link, useNavigate } from "react-router-dom";
import { Button, FormFeedback, FormGroup, Input, Label } from "reactstrap";
import { getUsersWithRoles } from "../../Managers/profileManager";

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
      const newUser = {
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
      console.log('newUser', newUser);
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
    <div className="container" style={{ maxWidth: "500px" }}>
      <h3>Sign Up</h3>
      <FormGroup>
        <Label>First Name</Label>
        <Input
          type="text"
          value={firstName}
          onChange={(e) => {
            setFirstName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Last Name</Label>
        <Input
          type="text"
          value={lastName}
          onChange={(e) => {
            setLastName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Email</Label>
        <Input
          type="email"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>User Name</Label>
        <Input
          type="text"
          value={userName}
          onChange={(e) => {
            setUserName(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Address</Label>
        <Input
          type="text"
          value={address}
          onChange={(e) => {
            setAddress(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label>Sign Up With Teacher?</Label><br/>
          <Input 
            required
            id="teacher-checkbox-yes" 
            className="radio-input" 
            type="radio"
            name="teacher"
            onClick={(e) => setSignUpWithTeacher(true)}
            />Yes
          <Input 
            required
            defaultChecked
            id="teacher-checkbox-no" 
            className="radio-input" 
            type="radio"
            name="teacher"
            onClick={(e) => setSignUpWithTeacher(false)}
            />No
      </FormGroup>
      {signUpWithTeacher == false ? null : 
      <FormGroup>
        <Label>Teacher</Label>
        <select
          required
          name="teacher"
          className="register-select"
          onChange={(e) => {
            setTeacherId(e.target.value*1);
          }}>
          <option value={0} name="teacher">Teachers</option>
          {teachers.map(t => {
            return (
              <option key={t.id} value={t.id} name="teacher">
                {`${t.firstName} ${t.lastName}`}
              </option>
            )
          })}
        </select>
      </FormGroup>}
      <FormGroup>
        <Label>Password</Label>
        <Input
          invalid={passwordMismatch}
          type="password"
          value={password}
          onChange={(e) => {
            setPasswordMismatch(false);
            setPassword(e.target.value);
          }}
        />
      </FormGroup>
      <FormGroup>
        <Label> Confirm Password</Label>
        <Input
          invalid={passwordMismatch}
          type="password"
          value={confirmPassword}
          onChange={(e) => {
            setPasswordMismatch(false);
            setConfirmPassword(e.target.value);
          }}
        />
        <FormFeedback>Passwords do not match!</FormFeedback>
      </FormGroup>
      <p style={{ color: "red" }} hidden={!registrationFailure}>
        Registration Failure
      </p>
      <Button
        color="primary"
        onClick={handleSubmit}
        disabled={passwordMismatch}
      >
        Register
      </Button>
      <p>
        Already signed up? Log in <Link to="/login">here</Link>
      </p>
    </div>
  );
}
