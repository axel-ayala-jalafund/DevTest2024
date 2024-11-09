import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Home from '../pages/Home'
import Polls from '../pages/Polls'
import PollsForm from '../components/features/PollsForm'

function AppRoutes() {
  return (
    <Routes>
        <Route path='/' element={ <Home/> }  />

        <Route path='/polls' element={ <Polls/> } />
        <Route path='/polls/create' element={ <PollsForm/> } />
    </Routes>
  )
}

export default AppRoutes