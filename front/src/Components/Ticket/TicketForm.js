import React from 'react'

function TicketForm() {

    let addTicket = e => {
        e.preventDefault();
    }

    return (
        <div>
            <h4>
                TicketForm
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
                <input placeholder="title" />
                <input placeholder="Description" />
            </form>
        </div>
    )
}

export default TicketForm