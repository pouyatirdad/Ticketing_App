import axios from 'axios';


var token = JSON.parse(localStorage.getItem('Key'));

const Api = axios.create({
    baseURL: "https://localhost:44398",
    headers: { "Authorization": `Bearer ${token}` }
    // timeout: 3000
});
export default Api;