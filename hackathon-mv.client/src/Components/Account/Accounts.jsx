import React, { useEffect } from "react";
import { fetchAllAccounts } from "./accountSlice";
import { useDispatch, useSelector } from "react-redux";
import {
  Typography,
  Divider,
  Box,
  Paper,
  Stack,
  Card,
  Grid,
} from "@mui/material";
import { createTheme, ThemeProvider, styled } from "@mui/material/styles";
import { Link } from "react-router-dom";
import { verifiedUser } from "../User/AuthSlice";

function Accounts() {
  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#f0efeb",
    ...theme.typography.body2,
    padding: theme.spacing(2),
    textAlign: "center",
    color: theme.palette.text.secondary,
  }));

  const theme = createTheme({
    typography: {
      fontFamily: [
        "-apple-system",
        "BlinkMacSystemFont",
        '"Segoe UI"',
        "Roboto",
        '"Helvetica Neue"',
        "Arial",
        "sans-serif",
        '"Apple Color Emoji"',
        '"Segoe UI Emoji"',
        '"Segoe UI Symbol"',
      ].join(","),
    },
  });

  const dispatch = useDispatch();

  const accounts = useSelector((state) => state.accounts.allAccounts);
  const isLoggedIn = useSelector((state) => !!state.auth.me.id);
  const userId = useSelector((state) => state.auth.me.id);
  console.log(userId);

  useEffect(() => {
    dispatch(verifiedUser());
    dispatch(fetchAllAccounts(userId));
  }, []);

  return (
    <div>
      {isLoggedIn ? (
        <div>
          {accounts.data?.map((account) => (
            <div key={account.id}>
              <ThemeProvider theme={theme}>
                <Link to={`/accounts/${account.id}`}>
                  <Box sx={{ width: "100%" }}>
                    <Stack>
                      <Paper style={{ margin: "10px" }}>
                        <Item>
                          <Typography
                            sx={{ fontWeight: "bold" }}
                            align="left"
                            variant="h4"
                          >
                            {`${account.class} Account(${account.accountNum})`}
                          </Typography>

                          <Typography
                            sx={{ fontWeight: "bold" }}
                            align="right"
                            variant="h4"
                          >
                            ${account.balance}
                          </Typography>
                          <Typography
                            sx={{ fontWeight: "bold" }}
                            align="right"
                            variant="h6"
                          >
                            Available Balance
                          </Typography>
                        </Item>
                        <Divider />
                      </Paper>
                    </Stack>
                  </Box>
                </Link>
              </ThemeProvider>
            </div>
          ))}
        </div>
      ) : (
        <p>you havent opened any accounts</p>
      )}
    </div>
  );
}

export default Accounts;
