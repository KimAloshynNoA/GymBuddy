import React from 'react';
import { AppBar, Toolbar, Typography, Button, IconButton } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import { Link } from 'react-router-dom';
import logo from './GymBuddyLogo.png';

function Header() {
  return (
    <AppBar position="static" style={{ background: '#EDEDED' }} elevation={0} sx={{ borderBottom: 1, borderColor: 'divider' }}>
      <Toolbar>
        <IconButton edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
          <MenuIcon />
        </IconButton>
        <img src={logo} style={{ marginRight: '10px', height: '100px' }} />
        <Typography variant="h6" color="inherit" noWrap sx={{ flexGrow: 1 }}>
        </Typography>
        <Button color="primary" variant="outlined" sx={{ my: 1, mx: 1.5 }}>
            <Link to="/login">Login</Link>
        </Button>
        <Button color="primary" variant="outlined" sx={{ my: 1, mx: 1.5 }}>
          Sign Up
        </Button>
      </Toolbar>
    </AppBar>
  );
}

export default Header;