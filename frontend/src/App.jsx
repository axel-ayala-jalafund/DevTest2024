import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import { BrowserRouter } from "react-router-dom";
import Navbar from "./components/common/Navbar";
import MainLayout from "./components/layout/MainLayout";
import AppRoutes from "./routes/AppRoutes";

function App() {
  const [count, setCount] = useState(0);

  return (
    <BrowserRouter>
      <div style={{
        display: 'flex',
        flexDirection: 'column',
        minHeight: '100vh'
      }}>
        <Navbar />
        <MainLayout>
          <AppRoutes/>
        </MainLayout>
      </div>
    </BrowserRouter>
  );
}

export default App;
