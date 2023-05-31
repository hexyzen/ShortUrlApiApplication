export default Object.freeze({
    GET_THUMBNAIL_BY_POSTID:
        process.env.REACT_APP_API_URL + "api/Post/GetThumbnailById?postId=",
    GET_IMAGE_BY_POSTID:
        process.env.REACT_APP_API_URL + "api/Post/GetImageById?postId=",
    ROUTE_TABLE_PAGE: "tablepage",
    ROUTE_LOGIN_PAGE: "loginpage",
    ROUTE_INFO_PAGE: "info/:id",
})