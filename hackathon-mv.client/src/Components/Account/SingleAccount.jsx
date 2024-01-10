import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import {
  Typography,
  Box,
  Paper,
  createTheme,
  ThemeProvider,
} from "@mui/material";
import { fetchSingleAccount } from "./accountSlice";
import { getAllTransactions } from "../Transactions/TransactionsSlice";

function SingleAccount() {
  const { id } = useParams();
  const dispatch = useDispatch();
  const account = useSelector((state) => state.accounts.singleAccount);
  const transactions = useSelector(
    (state) => state.transactions.allTransactions
  );

  console.log(transactions);

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
    dispatch(getAllTransactions(id));
  }, [dispatch, id]);

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
      <div>
        <Typography
          color="primary"
          align="center"
          sx={{ fontWeight: "bold" }}
          component="div"
          variant="h3"
        >
          All Transactions:
        </Typography>
        {transactions.map((transaction) => (
          <div key={transaction.id}>
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
                    variant="h6"
                  >
                    {transaction.name}
                  </Typography>
                  <Typography
                    color="primary"
                    align="right"
                    sx={{ fontWeight: "bold" }}
                    component="div"
                    variant="h4"
                  >
                    ${transaction.amount}
                  </Typography>
                </Paper>
              </Box>
            </ThemeProvider>
          </div>
        ))}
      </div>
    </div>
  );
}

export default SingleAccount;
