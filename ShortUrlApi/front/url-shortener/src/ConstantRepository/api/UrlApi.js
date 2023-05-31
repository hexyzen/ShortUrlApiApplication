import { baseApiFetch } from "./ApiInterceptor";
import Cookies from "js-cookie";

export function GetUrls() {
    return baseApiFetch("api/Url/GetUrls", {
        method: "GET",
        headers: {
            Authorization: "Bearer " + Cookies.get("JWT"),
        },
    });
}

export function CreateUrl(payload) {
    return baseApiFetch("api/Url/CreateUrl", {
        method: "POST",
        body: JSON.stringify(payload),
        headers: {
            Accept: "application/json",
            "content-type": "application/json",
            Authorization: "Bearer " + Cookies.get("JWT"),
        },
    });
}