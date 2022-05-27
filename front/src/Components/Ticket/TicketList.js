import React from 'react'

function TicketList(props) {

    return (
        <div>

            <h3>
                Ticket list :
            </h3>

            {
                props.data.map(x =>

                    x.map(z =>
                        <>
                            <h5>
                                {z.title}
                            </h5>
                            <p>
                                {z.description}
                            </p>
                        </>
                    )

                )
            }

        </div>
    )
}

export default TicketList