import React, { useEffect } from "react";
import { fetchAllAccounts } from "./accountSlice";
import { useDispatch, useSelector } from "react-redux";
import { Typography, Divider, Box, Paper, Stack } from "@mui/material";
import { createTheme, ThemeProvider, styled } from "@mui/material/styles";
import { Link } from "react-router-dom";

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

  console.log(accounts.data);

  useEffect(() => {
    dispatch(fetchAllAccounts());
  }, [dispatch]);

  return (
    <div>
      <div>
        {accounts.data?.map((account) => (
          <div key={account.id}>
            <ThemeProvider theme={theme}>
              <Link to={`/${account.id}`}>
                <Box sx={{ width: "100%" }}>
                  <Stack spacing={4}>
                    <Paper elevation={6} style={{ margin: "10px" }}>
                      <Item>
                        <Typography sx={{ fontWeight: "bold" }}>
                          {`${account.class}${account.accountNum}`}
                        </Typography>

                        <Typography sx={{ fontWeight: "bold" }}>
                          {account.putCardDown}
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
    </div>
  );
}

export default Accounts;
