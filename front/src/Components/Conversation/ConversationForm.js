import React, { useState } from 'react'
import Api from './../../Api/Api';

function ConversationForm() {

    const [State, setState] = useState({
        Text: "",
    })

    let MainSetState = data => {
        setState({ ...State, ...data });
    }

    let addTicket = e => {
        e.preventDefault();
        Api.post('/conversation/create', {
            id: 0,
            title: State.Text,
            status: 0,
            isDeleted: false
        }, { headers: { "Content-Type": "application/json" } })
            .then(res => res.status === 200
                ?
                MainSetState({ Text: '' })
                :
                alert("error"))
            .catch(er => console.log(`Error : ${er}`))
    }


    let OnChangeHandler = (e) => {
        MainSetState({ Text: e.target.value });
    }

    return (
        <div>
            <h4>
                ConversationForm
            </h4>
            <form onSubmit={addTicket}>
                <select>
                    <option>
                        user 1
                    </option>
                    <option>
                        user 2
                    </option>
                    <option>
                        user 3
                    </option>
                </select>
                <input value={State.Text} onChange={OnChangeHandler} placeholder="title" />
                <button>
                    submit
                </button>
            </form>
        </div>
    )
}

export default ConversationForm