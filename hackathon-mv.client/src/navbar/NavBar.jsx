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

import { useSelector, useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { logout } from "../store/index";

function NavBar() {
  const isLoggedIn = useSelector((state) => state.auth.me.id);
  const firstName = useSelector((state) => state.auth.me.firstName);
  const lastName = useSelector((state) => state.auth.me.lastName);

  const navigate = useNavigate();
  const dispatch = useDispatch();

  const logoutAndRedirectHome = () => {
    dispatch(logout());
    navigate("/");
  };

  const theme = createTheme({
    palette: {
      primary: {
        main: "#5b49ad",
        darker: "#066839",
      },
      secondary: {
        main: "#8291f5",
      },
    },
  });

  return (
    <div>
      {isLoggedIn ? (
        <ThemeProvider theme={theme}>
          <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static" color="primary">
              <Toolbar>
                <Typography
                  color="secondary"
                  variant="h6"
                  component="div"
                  sx={{ flexGrow: 1 }}
                  align="left"
                >
                  <Link to="/">Bank of Drew</Link>
                </Typography>

                <Typography
                  color="primary"
                  variant="h6"
                  component="div"
                  sx={{ flexGrow: 1 }}
                  align="right"
                >
                  <Link to="/">
                    Welcome, {"  "}
                    {firstName} {lastName}
                  </Link>
                </Typography>

                <Typography
                  color="primary"
                  variant="h6"
                  component="div"
                  sx={{ flexGrow: 1 }}
                  align="right"
                >
                  <Link to="/openAccount">Open Account</Link>
                </Typography>

                <Typography
                  color="primary"
                  variant="h6"
                  component="div"
                  sx={{ flexGrow: 1 }}
                  align="right"
                >
                  <Button
                    color="secondary"
                    type="button"
                    variant="contained"
                    sx={{ width: "25%" }}
                    onClick={logoutAndRedirectHome}
                  >
                    Logout
                  </Button>
                </Typography>
              </Toolbar>
            </AppBar>
          </Box>
        </ThemeProvider>
      ) : (
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
                  color="primary"
                  variant="h6"
                  component="div"
                  sx={{ flexGrow: 1 }}
                  align="left"
                >
                  <Link to="/">Bank of Drew</Link>
                </Typography>

                <Button color="secondary">
                  <Link to="/signup">Register</Link>
                </Button>

                <Button color="primary">
                  <Link to="/login">Login</Link>
                </Button>
              </Toolbar>
            </AppBar>
          </Box>
        </ThemeProvider>
      )}
    </div>
  );
}

export default NavBar;
