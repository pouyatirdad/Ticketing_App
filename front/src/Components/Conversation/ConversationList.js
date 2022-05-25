import React, { useEffect, useState } from 'react'
import Api from './../../Api/Api';
import { Link } from 'react-router-dom';

function ConversationList() {

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

        Api.get("/conversation/")
            .then(x => MainSetState({ data: [...State.data, x.data], error: false }))
            .catch(err => logFunc(err));

    }, [])

    return (
        <div>
            <h4>
                ConversationList
            </h4>

            {
                State.data.map(x =>
                    x.map(z =>

                        <div>
                            {z.title}
                            <Link to={`/Cvr/${z.id}`} key={z.id}>
                                تیکتها
                            </Link>
                        </div>
                    )
                )
            }

            {
                State.error ? "WE Got Error" : ""
            }
        </div>
    )
}

export default ConversationList