import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { login } from "../../Managers/authManger";
import { FormFeedback, FormGroup, Input, InputGroup, InputGroupText } from "reactstrap";
import { RiLockPasswordFill } from "react-icons/ri";
import { MdAlternateEmail } from "react-icons/md";
import "./auth.css";

export default function Login({ setLoggedInUser }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [failedLogin, setFailedLogin] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    login(email, password).then((user) => {
      if (!user) {
        setFailedLogin(true);
      } else {
        setLoggedInUser(user);
        navigate("/");
      }
    });
  };

  return (
    <div className="login-container">
      <div className="login-header">
        <h2>Login</h2>
      </div>
      <FormGroup>
        <InputGroup size="md">
          <InputGroupText>
            <MdAlternateEmail />
          </InputGroupText>
          <Input
            invalid={failedLogin}
            type="text"
            value={email}
            placeholder="email"
            onChange={(e) => {
              setFailedLogin(false);
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
            invalid={failedLogin}
            type="password"
            placeholder="password"
            value={password}
            onChange={(e) => {
              setFailedLogin(false);
              setPassword(e.target.value);
            }}
          />
        </InputGroup>
        <FormFeedback>Login failed.</FormFeedback>
      </FormGroup>

      <button className="animated-btn" onClick={handleSubmit}>
        Login
      </button>

      <p style={{margin:0}}>or</p>
        
      <Link to="/register">Create Account</Link>
    
    </div>
  );
}
