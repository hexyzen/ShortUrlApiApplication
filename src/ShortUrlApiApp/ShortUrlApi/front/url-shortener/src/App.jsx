import "./App.css"
import { Routes, Route } from "react-router-dom"
import NoPage from "./components/NoPage/NoPage"
import LoginPage from "./components/LoginPage/LoginPage"
import ConstantsList from "./ConstantRepository/ConstantsList"
import TablePage from "./components/TablePage/TablePage"
import InfoPage from "./components/InfoPage/InfoPage"

const App = () => {
  return (
    <Routes>
      <Route path={ConstantsList.ROUTE_LOGIN_PAGE} element={<LoginPage />} />
      <Route path={ConstantsList.ROUTE_TABLE_PAGE} element={<TablePage />} />
      <Route path={ConstantsList.ROUTE_INFO_PAGE} element={<InfoPage />} />
      <Route path="*" element={<NoPage />} />
    </Routes>
  )
}

export default App
