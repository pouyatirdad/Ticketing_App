import React, { useState } from 'react'
import Api from './../../Api/Api';

function Register() {
    const [State, setState] = useState({
        data: {
            username: "",
            email: "",
            password: "",
            retypepassword: ""
        },
        error: false,
    })

    let MainSetState = data => {
        setState({ ...State, ...data });
    }

    let logFunc = e => {
        console.log(`error : ${e}`);
        MainSetState({ data: "", error: true });
    }


    let submitRegister = e => {
        e.preventDefault();

        Api.post('/account/Register', {
            username: State.data.username,
            email: State.data.email,
            password: State.data.password,
            retypepassword: State.data.retypepassword
        })
            .then(x => MainSetState({ data: { username: "", email: "", password: "", retypepassword: "" }, error: false }))
            .catch(err => logFunc(err));

    }
    return (
        <div>

            <h2>
                Register
            </h2>

            {
                State.error ? <p> We Got Error </p> : ""
            }

            <form onSubmit={submitRegister}>
                <input placeholder="UserName"
                    value={State.data.username} onChange={(e) => { MainSetState({ data: { ...State.data, username: e.target.value }, error: false }) }} />

                <input placeholder="Email"
                    value={State.data.email} onChange={(e) => { MainSetState({ data: { ...State.data, email: e.target.value }, error: false }) }} />

                <input placeholder="Password"
                    value={State.data.password} onChange={(e) => { MainSetState({ data: { ...State.data, password: e.target.value }, error: false }) }} />

                <input placeholder="RetypePassword"
                    value={State.data.retypepassword} onChange={(e) => { MainSetState({ data: { ...State.data, retypepassword: e.target.value }, error: false }) }} />

                <button>
                    Submit
                </button>
            </form>

        </div>
    )
}

export default Register