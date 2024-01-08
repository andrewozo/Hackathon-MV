import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = { allAccounts: [], singleAccount: {} };

export const fetchAllAccounts = createAsyncThunk(
  "fetchAllAccounts",
  async () => {
    try {
      const { data } = await axios.get(
        "https://localhost:7276/api/Accounts/GetAll"
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
  },
});

export default accountsSlice.reducer;
