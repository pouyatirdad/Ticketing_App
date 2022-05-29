import React, { useState } from 'react'
import Api from './../../Api/Api';

function Login() {
    const [State, setState] = useState({
        data: {
            email: "",
            password: ""
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


    let submitLogin = e => {
        e.preventDefault();

        Api.post('/account/Login', {
            email: State.data.email,
            password: State.data.password
        })
            .then(x => console.log(x))
            .catch(err => logFunc(err));

    }
    return (
        <div>

            <h2>
                Login
            </h2>

            {
                State.error ? <p> We Got Error </p> : ""
            }

            <form onSubmit={submitLogin}>
                <input placeholder="Email"
                    value={State.data.email} onChange={(e) => { MainSetState({ data: { ...State.data, email: e.target.value }, error: false }) }} />

                <input placeholder="Password"
                    value={State.data.password} onChange={(e) => { MainSetState({ data: { ...State.data, password: e.target.value }, error: false }) }} />

                <button>
                    Submit
                </button>
            </form>

        </div>
    )
}

export default Login