import React, { useEffect, useState } from 'react'
import Api from './../../Api/Api';

function Alluser() {

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

        Api.get("/account/AllUser")
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
                            {z.userName}
                            <hr />
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

export default Alluser