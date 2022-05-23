import React from 'react'
import Header from './Header';
import './App.css';
import ConversationList from './Conversation/ConversationList';
import ConversationForm from './Conversation/ConversationForm';

const App = () => {
    return (
        <>
            <Header />
            <div style={{ display: 'flex', justifyContent: 'space-around', textAlign: 'center' }}>
                <div style={{ width: '80vw' }}>
                    <ConversationForm />
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