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
import { useSelector, useDispatch } from "react-redux";
import { verifiedUser } from "./Components/User/AuthSlice";
import SingleAccount from "./Components/Account/SingleAccount";

function AppRoutes() {
  const isLoggedIn = useSelector((state) => state.auth.me.id);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(verifiedUser());
  }, [dispatch]);

  return (
    <div>
      {isLoggedIn ? (
        <Routes>
          <Route path="/" element={<Accounts />} />
          <Route path="/signup" element={<AuthForm />} />
          <Route path="/login" element={<LoginAuthForm />} />
          <Route path="/accounts/:id" element={<SingleAccount />} />
        </Routes>
      ) : (
        <Routes>
          <Route path="/" element={<Accounts />} />
          <Route path="/signup" element={<AuthForm />} />
          <Route path="/login" element={<LoginAuthForm />} />
        </Routes>
      )}
    </div>
  );
}

export default AppRoutes;
