import React, { useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import {
  Typography,
  Box,
  Paper,
  createTheme,
  ThemeProvider,
  Button,
} from "@mui/material";
import { fetchSingleAccount } from "./accountSlice";

function SingleAccount() {
  const { id } = useParams();
  const dispatch = useDispatch();
  const account = useSelector((state) => state.accounts.singleAccount);

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

  useEffect(() => {
    dispatch(fetchSingleAccount(id));
  });

  return (
    <div>
      <ThemeProvider theme={theme}>
        <Box sx={{ width: "100%", boxShadow: 0 }}>
          <Paper
            style={{
              margin: "10px",
              padding: "10px",
              backgroundColor: "#f0efeb",
            }}
          >
            <Typography
              color="primary"
              align="left"
              sx={{ fontWeight: "bold" }}
              component="div"
              variant="h4"
            >
              {account.class} Account({account.accountNum})
            </Typography>
            <Typography
              color="primary"
              align="right"
              sx={{ fontWeight: "bold" }}
              component="div"
              variant="h4"
            >
              ${account.balance}
            </Typography>
          </Paper>
        </Box>
      </ThemeProvider>
    </div>
  );
}

export default SingleAccount;
