import axios from 'axios';

const API_URL = import.meta.env.VITE_API_URL || "https://localhost:7272/api";

export const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

api.interceptors.response.use(
  (response) => response,
  (error) => {
// Log detallado del error
    console.error(`API Error: ${error.response?.status} - ${error.message}`);
    return Promise.reject(error);
  }
);

