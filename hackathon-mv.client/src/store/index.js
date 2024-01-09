import { configureStore } from "@reduxjs/toolkit";
import accountsReducer from "../Components/Account/accountSlice";
import authReducer from "../Components/User/AuthSlice";

const store = configureStore({
  reducer: {
    accounts: accountsReducer,
    auth: authReducer,
  },
});

export default store;
export * from "../Components/User/AuthSlice";
