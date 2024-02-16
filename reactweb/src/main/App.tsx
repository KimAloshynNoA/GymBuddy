import React from 'react';
import logo from './logo.svg';
import './App.css';
import Header from './Header';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import HomePage from './HomePage'; 
import LoginPage from '../Login/page'; // Adjust the import path based on your file structure

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} /> 
        <Route path="/login" element={<LoginPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
