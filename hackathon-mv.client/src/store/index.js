import { configureStore } from "@reduxjs/toolkit";
import accountsReducer from "../Components/Account/accountSlice";
import authReducer from "../Components/User/AuthSlice";
import transactionsReducer from "../Components/Transactions/TransactionsSlice";

const store = configureStore({
  reducer: {
    accounts: accountsReducer,
    auth: authReducer,
    transactions: transactionsReducer,
  },
});

export default store;
export * from "../Components/User/AuthSlice";
