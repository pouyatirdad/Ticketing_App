import axios from 'axios';

const Api = axios.create({
    baseURL: "https://localhost:44398/",
    timeout: 3000
});
export default Api;