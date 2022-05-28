import React from 'react';
import ReactDOM from 'react-dom';
import App from './Components/App';
import ConversationDetail from './Components/Conversation/ConversationDetail';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Register from './Components/Account/Register';
import Login from './Components/Account/Login';

ReactDOM.render(

  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path='/' exact element={<App />} />
      <Route path="Cvr" element={<ConversationDetail />}>
        <Route path=":id" element={<ConversationDetail />} />
      </Route>
      <Route path='/register' exact element={<Register />} />
      <Route path='/login' exact element={<Login />} />
    </Routes>
  </BrowserRouter>
  , document.getElementById('root')
);

