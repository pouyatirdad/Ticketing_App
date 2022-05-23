import React from 'react';
import ReactDOM from 'react-dom';
import App from './Components/App';
import ConversationDetail from './Components/Conversation/ConversationDetail';
import { BrowserRouter, Routes, Route } from "react-router-dom";

ReactDOM.render(

  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path='/' exact element={<App />} />
      <Route path="Cvr" element={<ConversationDetail />}>
        <Route path=":id" element={<ConversationDetail />} />
      </Route>
    </Routes>
  </BrowserRouter>
  , document.getElementById('root')
);

