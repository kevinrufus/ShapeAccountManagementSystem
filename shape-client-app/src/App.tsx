import { Col, Row } from "antd";
import "./App.css";
import "antd-css-utilities/utility.min.css";
import { SignupForm } from "./Components/signupForm";

function App() {
  return (
    <Row className="d-flex">
      <Col span={7}></Col>
      <Col span={12}>
        <div className="">
          <SignupForm />
        </div>
      </Col>
      <Col span={7}></Col>
    </Row>
  );
}

export default App;
