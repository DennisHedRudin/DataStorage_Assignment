import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';  // Om du har en index.css
import App from './App';  // Se till att denna är korrekt
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

// Om du använder web vitals (det kan du ta bort om du inte behöver detta)
reportWebVitals();