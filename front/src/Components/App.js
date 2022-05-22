import React from 'react'
import Header from './Header';
import './App.css';
import ConversationList from './Conversation/ConversationList';
import ConversationForm from './Conversation/ConversationForm';
import { Route, Router, Switch } from 'react-router';

const App = () => {
    return (
        <>
            <Router>
                <Switch>
                    <Route path='/home' component={Home} />
                    <Route path='/' exact component={About} />
                    <Route path='/Cvr/:id' component={ConversationDetail} />
                    <Route path='eror' component={Eror} />
                    <Route path='' component={Eror} />
                </Switch>
            </Router>
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