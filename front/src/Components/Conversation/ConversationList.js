import React, { useEffect, useState } from 'react'
import Api from './../../Api/Api';
import { Link } from 'react-router-dom';

function ConversationList() {

    const [State, setState] = useState([])

    useEffect(() => {

        Api.get("/conversation/")
            .then(x => setState(x.data))
            .catch(err => console.log(`error : ${err}`));

    }, [])

    return (
        <div>
            <h4>
                ConversationList
            </h4>

            {
                State.map(x =>
                    <div>
                        {x.title}
                        <Link to={`/Cvr/${x.id}`} key={x.id}>
                            تیکتها
                        </Link>
                    </div>
                )
            }
        </div>
    )
}

export default ConversationList