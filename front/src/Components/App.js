import React from 'react'
import Header from './Header';
import './App.css';
import ConversationList from './Ticket/ConversationList';
import TicketForm from './Ticket/TicketForm';

const App = () => {
    return (
        <>
            <Header />
            <div style={{ display: 'flex', justifyContent: 'space-around', textAlign: 'center' }}>
                <div style={{ width: '80vw' }}>
                    <TicketForm />
                    <ConversationList />
                </div>
                <div style={{ width: '20vw', borderLeft: '1px solid #000' }}>
                    this is right sidebar
                </div>
            </div>
        </>
    )
}

export default App