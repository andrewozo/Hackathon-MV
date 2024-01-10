import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = { allTransactions: [], singleTransaction: {} };

export const getAllTransactions = createAsyncThunk(
  "getAllTransactions",
  async (id) => {
    try {
      const { data } = await axios.get(
        `https://localhost:7276/api/Transaction/GetAll?accId=${id}`
      );

      return data.data;
    } catch (error) {
      console.log(error);
    }
  }
);

const transactionsSlice = createSlice({
  name: "transactions",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getAllTransactions.fulfilled, (state, action) => {
      state.allTransactions = action.payload;
    });
  },
});

export default transactionsSlice.reducer;
