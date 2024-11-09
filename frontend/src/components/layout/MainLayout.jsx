import { Container } from '@mui/material'
import React from 'react'

function MainLayout({ children }) {
  return (
    <Container
        component="main"
        sx={{
            mt: 4,
            flex: 1,
            display: 'flex',
            flexDirection: 'column'
        }}
    >
        {children}
    </Container>
  )
}

export default MainLayout