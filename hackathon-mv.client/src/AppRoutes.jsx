import { useEffect } from "react";

import { Routes, Route } from "react-router-dom";
import Accounts from "./Components/Account/Accounts";
import "./App.css";
import AuthForm from "./Components/User/AuthForm";
import LoginAuthForm from "./Components/User/LoginAuthForm";
import { useSelector, useDispatch } from "react-redux";
import { verifiedUser } from "./Components/User/AuthSlice";
import SingleAccount from "./Components/Account/SingleAccount";
import AddAccount from "./Components/Account/AddAccount";

function AppRoutes() {
  const isLoggedIn = useSelector((state) => state.auth.me.id);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(verifiedUser());
  }, [dispatch]);

  return (
    <div>
      {isLoggedIn ? (
        <Routes>
          <Route path="/" element={<Accounts />} />
          <Route path="/signup" element={<AuthForm />} />
          <Route path="/login" element={<LoginAuthForm />} />
          <Route path="/accounts/:id" element={<SingleAccount />} />
          <Route path="/openAccount" element={<AddAccount />} />
        </Routes>
      ) : (
        <Routes>
          <Route path="/" element={<Accounts />} />
          <Route path="/signup" element={<AuthForm />} />
          <Route path="/login" element={<LoginAuthForm />} />
        </Routes>
      )}
    </div>
  );
}

export default AppRoutes;
