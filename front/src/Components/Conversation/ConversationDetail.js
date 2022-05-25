import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router';
import Api from './../../Api/Api';
import TicketForm from './../Ticket/TicketForm';

function ConversationDetail() {
    let params = useParams();

    const [State, setState] = useState({
        data: [],
        error: false,
    })

    let MainSetState = data => {
        setState({ ...State, ...data });
    }

    let logFunc = e => {
        console.log(`error : ${e}`);
        MainSetState({ data: [...State.data], error: true });
    }

    useEffect(() => {

        Api.get(`/ticket/GetByConversation/${params.id}`)
            .then(x => MainSetState({ data: [...State.data, x.data], error: false }))
            .catch(err => logFunc(err));

    }, [])

    return (
        <>
            <TicketForm id={params.id} />
            <div>ConversationDetail</div>
        </>
    )
}

export default ConversationDetail