import { useEffect } from "react";
import {
  AppBar,
  Box,
  Toolbar,
  Typography,
  Button,
  IconButton,
  createTheme,
  ThemeProvider,
} from "@mui/material/";
import MenuIcon from "@mui/icons-material/Menu";
import { Link, Routes, Route } from "react-router-dom";
import Accounts from "./Components/Account/Accounts";
import "./App.css";
import AuthForm from "./Components/User/AuthForm";
import LoginAuthForm from "./Components/User/LoginAuthForm";
import NavBar from "./navbar/NavBar";
import AppRoutes from "./AppRoutes";

function App() {
  useEffect(() => {}, []);

  const theme = createTheme({
    palette: {
      primary: {
        main: "#066839",
        darker: "#066839",
      },
      secondary: {
        main: "#fefae0",
      },
    },
  });

  return (
    <div>
      <NavBar />
      <AppRoutes />
    </div>
  );
}

export default App;
