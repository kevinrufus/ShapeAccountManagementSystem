import { Button, Col, Form, Input, message, Row, Spin } from "antd";
import { signupReq } from "../Requests";
import { ResponseModel } from "../Requests/ResponseModel";
import { LoadingOutlined } from '@ant-design/icons';
import { useState } from "react";


export const SignupForm = () => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const antIcon = <LoadingOutlined style={{ fontSize: 24 }} spin />;

  const passwodRegex = new RegExp(
    "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&<>./-]).{8,}$"
  );

  const submitForm = async (data:any) => {
    setIsLoading(true);
    const result: ResponseModel = await signupReq('signup', data);
    setIsLoading(false);
    if(result.isSuccess)
        message.success(result.message);
    else
        message.error("Account not created");
  };

  return (
    <>
    <Spin indicator={antIcon} spinning={isLoading} size='large'>
      <div className="pt-15 pb-10">
        <h2>Create Shape Account</h2>
      </div>
      <Form
        name="basic"
        labelCol={{ span: 12 }}
        wrapperCol={{ span: 24 }}
        style={{ maxWidth: 600 }}
        initialValues={{ remember: true }}
        onFinish={submitForm}
        autoComplete="off"
        layout="vertical"
      >
        <Row>
          <Col span={11} className="mr-12">
            <Form.Item
              label="First Name"
              name="firstName"
              rules={[
                { required: true, message: "Please input your first name!" },
              ]}
            >
              <Input placeholder="First Name" autoComplete="firstName"/>
            </Form.Item>
          </Col>
          <Col span={11}>
            <Form.Item
              label="Last Name"
              name="lastName"
              rules={[
                { required: true, message: "Please input your last name!" },
              ]}
            >
              <Input placeholder="Last Name" autoComplete="lastName"/>
            </Form.Item>
          </Col>
        </Row>
        <Row>
          <Col span={24}>
            <Form.Item
              label="Work Email Address"
              name="email"
              rules={[
                {
                  required: true,
                  message: "Please input your work email address!",
                },
                {
                  type: "email",
                  message: "Invalid email",
                },
              ]}
            >
              <Input placeholder="Work Email Address" autoComplete="email"/>
            </Form.Item>
          </Col>
        </Row>
        <Row>
          <Col span={24}>
            <Form.Item
              label="Password"
              name="password"
              hasFeedback
              rules={[
                { required: true, message: "Please input your password!" },
                () => ({
                  validator(_, value) {
                    if (passwodRegex.test(value)) {
                      return Promise.resolve();
                    }
                    return Promise.reject(
                      new Error(
                        "The entered password is not valid. Passwords must be at least 8 characters in length include at least one uppercase letter, one lowercase letter, one number and two special characters."
                      )
                    );
                  },
                }),
              ]}
            >
              <Input.Password placeholder="Password" autoComplete="new-password"/>
            </Form.Item>
          </Col>
        </Row>
        <Row>
          <Col span={24}>
            <Form.Item
              label="Confirm Password"
              name="confirmPassword"
              dependencies={["password"]}
              hasFeedback
              rules={[
                { required: true, message: "Please confirm your password!" },
                ({ getFieldValue }) => ({
                  validator(_, value) {
                    if (!value || getFieldValue("password") === value) {
                      return Promise.resolve();
                    }
                    return Promise.reject(
                      new Error("The passwords that you entered do not match!")
                    );
                  },
                }),
              ]}
            >
              <Input.Password placeholder="Confirm Password" autoComplete="confirm-password"/>
            </Form.Item>
          </Col>
        </Row>
        <Form.Item wrapperCol={{ offset: 10, span: 24 }}>
          <Button
            type="primary"
            htmlType="submit"
            shape="round"
            style={{ backgroundColor: "green" }}
            size="large"
          >
            Sign up
          </Button>
        </Form.Item>
      </Form>
      </Spin>
    </>
  );
};
