import { configureStore } from "@reduxjs/toolkit";
import accountsReducer from "../Components/Account/accountSlice";

const store = configureStore({
  reducer: {
    accounts: accountsReducer,
  },
});

export default store;
