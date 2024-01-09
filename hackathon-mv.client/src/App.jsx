import { useEffect } from "react";

import "./App.css";

import NavBar from "./navbar/NavBar";
import AppRoutes from "./AppRoutes";

function App() {
  useEffect(() => {}, []);

  return (
    <div>
      <NavBar />
      <AppRoutes />
    </div>
  );
}

export default App;
