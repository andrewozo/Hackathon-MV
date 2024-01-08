import { useEffect, useState } from "react";
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
      <ThemeProvider theme={theme}>
        <Box sx={{ flexGrow: 1 }}>
          <AppBar position="static" color="primary">
            <Toolbar>
              <IconButton
                size="large"
                edge="start"
                color="secondary"
                aria-label="menu"
                sx={{ mr: 2 }}
              >
                <MenuIcon />
              </IconButton>

              <Typography
                color="secondary"
                variant="h6"
                component="div"
                sx={{ flexGrow: 1 }}
                align="center"
              >
                <Link to="/">Bank of Drew</Link>
              </Typography>

              <Button color="secondary">
                <Link to="/newActivity">Add New</Link>
              </Button>
            </Toolbar>
          </AppBar>
        </Box>
      </ThemeProvider>
      <Routes>
        <Route path="/" element={<Accounts />} />
      </Routes>
    </div>
  );
}

export default App;
