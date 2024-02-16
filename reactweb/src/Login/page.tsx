import React, { useState } from 'react';
import { Box, TextField, Button } from '@mui/material';
import { spacing } from '@mui/system';
import '../main/App.css';


function LoginPage() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (event: { preventDefault: () => void; }) => {
    event.preventDefault();
    try {
      const response = await fetch('https://localhost:7078/api/auth', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password }),
      });

      if (!response.ok) throw new Error('Login failed');

      const { token } = await response.json();
      localStorage.setItem('token', token); // Store the token
      // Redirect user or update app state
    } catch (error) {
      console.error(error);
      // Handle login error (show message to user)
    }
  };

  return (
    <div className="application">
        <Box
        component="form"
        onSubmit={handleSubmit}
        sx={{
            '& .MuiTextField-root': { m: 1, width: '25ch' },
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            justifyContent: 'center',
            paddingTop: 60
        }}
        noValidate
        autoComplete="off"
        >
        <TextField
            label="Username"
            variant="outlined"
            required
            value={username}
            onChange={(e) => setUsername(e.target.value)}
        />
        <TextField
            label="Password"
            type="password"
            variant="outlined"
            required
            value={password}
            onChange={(e) => setPassword(e.target.value)}
        />
        <Button type="submit" variant="contained" sx={{ 
            backgroundColor: '#ff5722', // Custom color
            '&:hover': {
                backgroundColor: '#e64a19', // Darker shade for hover state
            },
            mt: 2, mb: 2 }}>
            Login
        </Button>
        </Box>
    </div>
  );
}


export default LoginPage;