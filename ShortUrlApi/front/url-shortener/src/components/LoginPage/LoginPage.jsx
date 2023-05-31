import React, { useState } from "react"
import { TextField, Button } from "@mui/material"
import "./loginPage.css"
import { Login } from "../../ConstantRepository/api/UserApi"
import Cookies from "js-cookie"
import ConstantsList from "../../ConstantRepository/ConstantsList"
import { useNavigate } from "react-router-dom"

const LoginPage = () => {
  const [username, setUsername] = useState("")
  const [password, setPassword] = useState("")

  let navigate = useNavigate()

  async function handleLogin() {
    const body = {
      Username: username,
      Password: password,
    }

    await Login(body)
      .then((data) => data.json())
      .then((response) => {
        if (response.status != 404 && response.status != 401) {
          Cookies.set("JWT", response)
        } else {
          alert("Login or password is incorrect")
        }
      })
    await navigate(`/${ConstantsList.ROUTE_TABLE_PAGE}`)
  }

  return (
    <div className="login-container">
      <div className="login-form">
        <h2>Login</h2>
        <form>
          <TextField
            label="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            fullWidth
          />
          <TextField
            label="Password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            fullWidth
          />
          <Button variant="contained" onClick={handleLogin}>
            Login
          </Button>
        </form>
      </div>
    </div>
  )
}

export default LoginPage
