import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = { allAccounts: [], singleAccount: {} };

export const fetchAllAccounts = createAsyncThunk(
  "fetchAllAccounts",
  async () => {
    const token = window.localStorage.getItem("token");
    try {
      const response = await axios.get(
        `https://localhost:7276/api/Auth/api/me?token=${token}`
      );
      const userId = response.data.data.id;
      const { data } = await axios.get(
        `https://localhost:7276/api/Accounts/GetAll?userId=${userId}`
      );
      // console.log(response.data.data.id);
      // console.log(data);
      return data;
    } catch (error) {
      console.log(error);
    }
  }
);

export const fetchSingleAccount = createAsyncThunk(
  "fetchSingleAccount",
  async (id) => {
    try {
      const { data } = await axios.get(
        `https://localhost:7276/api/Accounts/${id}`
      );

      console.log(data);

      return data.data;
    } catch (error) {
      console.log(error);
    }
  }
);

export const addAccount = createAsyncThunk(
  "createAccount",
  async ({ accNum, balance, account }) => {
    const token = window.localStorage.getItem("token");
    try {
      const response = await axios.get(
        `https://localhost:7276/api/Auth/api/me?token=${token}`
      );
      const userId = response.data.data.id;
      const { data } = await axios.post(
        `https://localhost:7276/api/Accounts?userId=${userId}`,
        {
          accountNum: accNum,
          balance: balance,
          class: account,
        }
      );

      return data;
    } catch (error) {
      console.log(error);
    }
  }
);

const accountsSlice = createSlice({
  name: "accounts",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(fetchAllAccounts.fulfilled, (state, action) => {
      state.allAccounts = action.payload;
    });
    builder.addCase(fetchSingleAccount.fulfilled, (state, action) => {
      state.singleAccount = action.payload;
    });
    builder.addCase(addAccount.fulfilled, (state, action) => {
      state.allAccounts.push(action.payload);
    });
  },
});

export default accountsSlice.reducer;
