import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const register = createAsyncThunk("register", async (userData) => {
  try {
    const response = await axios.post(
      "https://localhost:7276/api/Auth/Register",
      userData
    );

    console.log(response);

    return response.data;
  } catch (error) {
    console.log(error);
  }
});

export const signin = createAsyncThunk("signin", async (userData) => {
  try {
    const { data } = await axios.post(
      "https://localhost:7276/api/Auth/Login",
      userData
    );

    console.log(data.data);
    window.localStorage.setItem("token", data.data);
    return data.data;
  } catch (error) {
    console.log(error);
  }
});

export const verifiedUser = createAsyncThunk("auth/me", async () => {
  const token = window.localStorage.getItem("token");
  try {
    if (token) {
      const { data } = await axios.get(
        `https://localhost:7276/api/Auth/api/me?token=${token}`
      );
      console.log(data.data);
      return data.data;
    } else {
      return {};
    }
  } catch (error) {
    console.log(error);
  }
});

const authSlice = createSlice({
  name: "auth",
  initialState: {
    me: {},
    error: null,
    loading: false,
    failed: false,
  },

  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(register.fulfilled, (state, action) => {});
    builder.addCase(verifiedUser.fulfilled, (state, action) => {
      state.me = action.payload;
      state.loading = false;
    });
  },
});

export default authSlice.reducer;
