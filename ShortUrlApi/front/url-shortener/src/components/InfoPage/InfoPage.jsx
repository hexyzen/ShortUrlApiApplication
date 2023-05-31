import React, { useState, useEffect } from "react"

const InfoPage = ({ urlId }) => {
  const [urlInfo, setUrlInfo] = useState(null)

  useEffect(() => {
    fetchUrlInfo()
  }, [])

  const fetchUrlInfo = () => {}

  return (
    <div>
      <h2>Short URL Info</h2>
      {urlInfo ? (
        <div>
          <p>URL ID: {urlInfo.id}</p>
          <p>Original URL: {urlInfo.originalUrl}</p>
          <p>Short URL: {urlInfo.shortUrl}</p>
        </div>
      ) : (
        <p>Loading URL info...</p>
      )}
    </div>
  )
}

export default InfoPage
