import React, { useState, useEffect } from "react"
import { CreateUrl, GetUrls } from "../../ConstantRepository/api/UrlApi"
import Cookies from "js-cookie"
import "./tablePage.css"
import Button from "@mui/material/Button"
import TextField from "@mui/material/TextField"

const TablePage = () => {
  const [urls, setUrls] = useState([])
  const [originalUrl, setOriginalUrl] = useState("")
  const [errorMessage, setErrorMessage] = useState("")
  const [isAuthorized, setIsAuthorized] = useState(false)

  useEffect(() => {
    const acookie = Cookies.get("JWT")
    if (acookie) {
      setIsAuthorized(true)
    }
    fetchUrls()
  }, [])

  const fetchUrls = async () => {
    try {
      await GetUrls()
        .then((data) => data.json())
        .then((response) => {
          setUrls(response)
        })
    } catch (error) {
      console.log(error)
    }
  }

  const handleViewDetails = (id) => {
    // Implement view details logic, e.g., navigate to Short URL Info view
    console.log(`View details for URL with ID: ${id}`)
  }

  const handleDeleteUrl = async (id) => {
    try {
      // Make API call to delete the URL
      await fetch(`/api/Url/DeleteUrl/${id}`, { method: "DELETE" })

      // Update the 'urls' state by filtering out the deleted URL
      setUrls(urls.filter((url) => url.id !== id))
    } catch (error) {
      console.log(error)
    }
  }

  const handleAddUrl = async (e) => {
    try {
      e.preventDefault()

      // Convert the originalUrl to a tiny format
      const responseShort = await fetch(
        `https://api.shrtco.de/v2/shorten?url=${originalUrl}`
      )
      const data = await responseShort.json()
      const shortUrl = data.result.full_short_link
      console.log(shortUrl)

      // Create the request body with the tinyUrl
      const body = {
        OriginalUrl: originalUrl,
        ShortUrl: shortUrl,
      }

      const response = await CreateUrl(body)

      if (response.ok) {
        await fetchUrls()
        setOriginalUrl("")
        setErrorMessage("")
      } else if (response.status === 409) {
        setErrorMessage("URL already exists")
      } else {
        setErrorMessage("An error occurred")
      }
    } catch (error) {
      console.log(error)
      setErrorMessage("An error occurred")
    }
  }

  return (
    <div className="table-page">
      <h2>Short URLs Table</h2>

      {isAuthorized && (
        <div className="add-url-form">
          <h3>Add New URL</h3>
          <form onSubmit={handleAddUrl}>
            <TextField
              type="text"
              value={originalUrl}
              onChange={(e) => setOriginalUrl(e.target.value)}
              placeholder="Enter URL"
            />
            <Button variant="contained" type="submit">
              Add
            </Button>
          </form>
          {errorMessage && <p>{errorMessage}</p>}
        </div>
      )}

      <table className="table">
        <thead>
          <tr>
            <th>Original URL</th>
            <th>Short URL</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {urls.map((url) => (
            <tr key={url.id}>
              <td>{url.originalUrl}</td>
              <td>{url.shortUrl}</td>
              <td>
                {isAuthorized && (
                  <>
                    <Button onClick={() => handleViewDetails(url.id)}>
                      View
                    </Button>
                    <Button onClick={() => handleDeleteUrl(url.id)}>
                      Delete
                    </Button>
                  </>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default TablePage
