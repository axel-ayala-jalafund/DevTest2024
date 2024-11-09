import axios from "axios";

const API_CONFIG = {
  BASE_URL: "http://localhost:5265/api/",
  TIMEOUT: 1000,
  HEADERS: {
    "Content-Type": "application/json",
  },
};

const axiosInstance = axios.create({
  baseURL: API_CONFIG.BASE_URL,
  timeout: API_CONFIG.TIMEOUT,
  headers: API_CONFIG.HEADERS,
});

axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.message) {
      switch (error.response.status) {
        case 404:
          console.error("Resource not found");
          break;

        case 500:
          console.error("Server error");
          break;

        default:
          console.log("An error ocurred");
      }
    }
    return Promise.reject(error);
  }
);

export default axiosInstance;
