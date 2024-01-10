import { useEffect } from "react";
import { fetchAllAccounts } from "./accountSlice";
import { useDispatch, useSelector } from "react-redux";
import { makeStyles } from "@material-ui/core/styles";
import { Typography, Divider, Box, Paper, Stack } from "@mui/material";
import { Container, CssBaseline } from "@material-ui/core";
import { createTheme, ThemeProvider, styled } from "@mui/material/styles";
import AccountBalanceIcon from "@material-ui/icons/AccountBalance";
import { Link } from "react-router-dom";
import { verifiedUser } from "../User/AuthSlice";

const useStyles = makeStyles((theme) => ({
  content: {
    marginTop: theme.spacing(8),
    marginBottom: theme.spacing(2),
    // backgroundColor: "#e8e7e3",
    padding: theme.spacing(3),
    borderRadius: theme.spacing(2),
  },
}));

function Accounts() {
  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === "dark" ? "#1A2027" : "#e8e7e3",
    ...theme.typography.body2,
    padding: theme.spacing(2),
    textAlign: "center",
    color: theme.palette.text.secondary,
  }));

  const classes = useStyles();

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
  }, [dispatch, userId]);

  return (
    <div>
      {isLoggedIn ? (
        <div>
          {accounts.data?.length > 0 ? (
            accounts.data?.map((account) => (
              <div key={account.id}>
                <ThemeProvider theme={theme}>
                  <Link to={`/accounts/${account.id}`}>
                    <Box sx={{ width: "100%" }}>
                      <Stack>
                        <Paper style={{ margin: "10px" }}>
                          <Item>
                            <Typography
                              color="#426375"
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
            ))
          ) : (
            <div>
              <CssBaseline />
              <Container component="main" className={classes.content}>
                <AccountBalanceIcon fontSize="large" />

                <Typography variant="h3" align="center" paragraph>
                  Welcome to the Bank of Drew family! 🎉 {"We're "} excited to
                  have you on board as our newest customer. Your next step is to
                  open an account
                </Typography>
              </Container>
            </div>
          )}
        </div>
      ) : (
        <div>
          <CssBaseline />
          <Container component="main" className={classes.content}>
            <AccountBalanceIcon fontSize="large" />
            <Typography variant="h2" component="h1" align="center" gutterBottom>
              Welcome to the Bank of Drew
            </Typography>
            <Typography variant="h3" align="center" paragraph>
              Hey there, future billionaire! 🚀 Welcome to the Bank of Drew,
              where we take banking as seriously as we take our morning coffee.
              Forget about the snooze-fest of traditional banks; with us,
              {"it's "}
              all about laughter, financial adventures, and making your money
              feel loved. Buckle up for a rollercoaster of financial fun – where
              banking meets a stand-up comedy show! 😄💸
            </Typography>
          </Container>
        </div>
      )}
    </div>
  );
}

export default Accounts;
