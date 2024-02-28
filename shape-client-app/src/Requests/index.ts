import { message } from "antd";
import axios from "axios";
import { ResponseModel } from "./ResponseModel";
axios.defaults.baseURL = "http://localhost:5180/User";

export const signupReq =async (url: string, data: any) => {
    try {
        const response: ResponseModel = await axios.post(url, data, {});
        return response?.data;
    }
    catch (e: any) {
        message.error(e.response.data.message);
        console.error("error", e);
    }
};
