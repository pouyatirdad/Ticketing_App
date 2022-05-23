import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router';
import Api from './../../Api/Api';

function ConversationDetail() {
    let params = useParams();

    const [State, setState] = useState([])

    useEffect(() => {

        Api.get(`/ticket/GetByConversation/${params.id}`)
            .then(x => setState(x.data))
            .catch(err => console.log(`error : ${err}`));

    }, [])

    return (
        <div>ConversationDetail</div>
    )
}

export default ConversationDetail