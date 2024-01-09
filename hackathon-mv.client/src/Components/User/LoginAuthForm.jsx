import React, { useState } from "react";
import {
  TextField,
  Stack,
  Typography,
  Paper,
  Button,
  FormControl,
  createTheme,
  ThemeProvider,
} from "@mui/material";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { signin } from "../User/AuthSlice";

function LoginAuthForm() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [email, setEmail] = useState("");

  const [password, setPassword] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();
    dispatch(signin({ email, password }));
    navigate("/");
  };

  const theme = createTheme({
    palette: {
      primary: {
        main: "#284b63",
      },
      secondary: {
        main: "#fca311",
      },
    },
  });

  return (
    <div>
      <div>
        <div>
          <ThemeProvider theme={theme}>
            <Paper
              elevation={0}
              sx={{ width: "100%", paddingTop: "80px", paddingBottom: "25px" }}
            >
              <Typography
                color="primary"
                align="center"
                sx={{ fontWeight: "bold" }}
                component="div"
                variant="h4"
              >
                Enter Login Credentials:
              </Typography>
              <form
                style={{
                  display: "flex",
                  textAlign: "center",
                  flexDirection: "column",
                  width: "100%",
                }}
                onSubmit={handleSubmit}
              >
                <Stack spacing={8}>
                  <FormControl
                    variant="outlined"
                    sx={{
                      width: "100%",
                      input: { color: "rgb(156 163 175)" },
                      "& .MuiFormLabel-root": {
                        color: "#066839",
                      },
                      "& .MuiOutlinedInput-root": {
                        "& > fieldset": {
                          borderColor: "#066839",
                          boxShadow: "6",
                        },
                      },
                      "& .MuiOutlinedInput-root.Mui-focused": {
                        "& > fieldset": {
                          borderColor: "#066839",
                          boxShadow: "6",
                        },
                      },
                    }}
                  >
                    <Paper
                      elevation={0}
                      sx={{ width: "100%", paddingTop: "15px" }}
                    >
                      <TextField
                        required
                        id="outline-required"
                        label="Email"
                        value={email}
                        onChange={(event) => setEmail(event.target.value)}
                        sx={{ width: "40%" }}
                      />
                    </Paper>

                    <Paper
                      elevation={0}
                      sx={{ width: "100%", paddingTop: "15px" }}
                    >
                      <TextField
                        required
                        id="outline-required"
                        label="Password"
                        value={password}
                        onChange={(event) => setPassword(event.target.value)}
                        sx={{ width: "40%" }}
                      />
                    </Paper>
                  </FormControl>
                </Stack>

                <div style={{ paddingTop: "25px" }}>
                  <Button
                    type="submit"
                    variant="contained"
                    sx={{ width: "25%" }}
                  >
                    Submit
                  </Button>
                </div>
              </form>
            </Paper>
          </ThemeProvider>
        </div>
      </div>
    </div>
  );
}

export default LoginAuthForm;
