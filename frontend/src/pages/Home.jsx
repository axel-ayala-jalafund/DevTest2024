
import { Box, Card, CardContent, Typography } from '@mui/material'
import React from 'react'

function Home() {
  return (
    <Box>
        <Typography variant='h4' gutterBottom>
            Welcome to Polls APP
        </Typography>
        <Card>
            <CardContent>
                <Typography variant='h6'>
                    What you dan do here:
                </Typography>
                <Typography>
                    - Vote for polls
                </Typography>
            </CardContent>
        </Card>
    </Box>
  )
}

export default Home