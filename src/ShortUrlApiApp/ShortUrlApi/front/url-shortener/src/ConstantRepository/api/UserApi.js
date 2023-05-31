import { baseApiFetch } from "./ApiInterceptor";
import Cookies from "js-cookie";

export function Login(payload) {
    return baseApiFetch("api/User/Login", {
        method: "POST",
        body: JSON.stringify(payload),
        headers: {
            Accept: "application/json",
            "content-type": "application/json",
        },
    });
}