import { useState } from "react";
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
import InputLabel from "@mui/material/InputLabel";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { addAccount } from "../Account/accountSlice";

function generateRandomNum() {
  const randomNumber = Math.floor(Math.random() * 900000000) + 100000000;
  return randomNumber;
}

function AddAccount() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const [balance, setBalance] = useState("0");
  const [account, setAccount] = useState("");
  let accNum = generateRandomNum();

  const handleSubmit = async (event) => {
    event.preventDefault();
    dispatch(addAccount({ accNum, balance, account }));
    navigate("/");
  };

  const handleChange = (event) => {
    setAccount(event.target.value);
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
              Enter Information:
            </Typography>
            <form
              style={{
                display: "flex",
                textAlign: "center",
                flexDirection: "column",
                width: "100%",
                height: "100%",
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
                      id="outlined-required"
                      label="Initial Balance"
                      value={balance}
                      onChange={(event) => setBalance(event.target.value)}
                      sx={{ width: "40%" }}
                    />
                  </Paper>

                  <Paper
                    elevation={0}
                    sx={{ width: "100%", paddingTop: "55px" }}
                  >
                    <Select
                      sx={{ width: "40%" }}
                      id="outline-required"
                      label="Type of Account"
                      value={account}
                      onChange={handleChange}
                    >
                      <InputLabel sx={{ width: "40%" }}>Acc</InputLabel>
                      <MenuItem value={"Checkings"}>Checkings</MenuItem>
                      <MenuItem value={"Savings"}>Savings</MenuItem>
                    </Select>
                  </Paper>
                </FormControl>
              </Stack>

              <div style={{ paddingTop: "25px" }}>
                <Button type="submit" variant="contained" sx={{ width: "25%" }}>
                  Submit
                </Button>
              </div>
            </form>
          </Paper>
        </ThemeProvider>
      </div>
    </div>
  );
}

export default AddAccount;
