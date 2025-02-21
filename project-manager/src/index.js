import React from 'react';  // Behåll den här raden
import ReactDOM from 'react-dom/client';
import './index.css'; // Importera din Tailwind CSS-fil här
import App from './App';
import reportWebVitals from './reportWebVitals';

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

// Optional: Start measuring performance
reportWebVitals();