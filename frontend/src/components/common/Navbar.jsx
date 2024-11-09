import { AppBar, Button, Toolbar, Typography } from '@mui/material';
import React from 'react'
import { useNavigate } from 'react-router-dom'

function Navbar() {
    const navigate = useNavigate();

  return (
    <AppBar position='sticky'>
        <Toolbar>
            <Typography variant='h6' sx={{ flexGrow: 1 }}>
                Movies App
            </Typography>
            <Button color='inherit' onClick={() => navigate('/')} sx={{
                marginRight: "25px"
            }}>
                Polls
            </Button>
        </Toolbar>
    </AppBar>
  )
}

export default Navbar;