import React, { useState } from 'react'
import Api from './../../Api/Api';

function TicketForm(props) {

    const [State, setState] = useState({
        data: {
            title: "",
            description: ""
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


    let submitTicket = e => {
        e.preventDefault();

        Api.post('/ticket/Create', {
            id: 0,
            title: State.data.title,
            description: State.data.description,
            status: 0,
            isDeleted: false,
            conversationID: props.id
        })
            .then(x => MainSetState({ data: { title: "", description: "" }, error: false }))
            .catch(err => logFunc(err));

    }

    return (
        <>
            <form onSubmit={submitTicket} style={{ margin: "20px" }}>
                <input value={State.data.title} onChange={(e) => { MainSetState({ data: { ...State.data, title: e.target.value }, error: false }) }} />
                <br />
                <input value={State.data.description} cols="30" onChange={(e) => { MainSetState({ data: { ...State.data, description: e.target.value }, error: false }) }} />
                <br />
                <button>
                    Submit
                </button>
            </form>
        </>
    )
}

export default TicketForm