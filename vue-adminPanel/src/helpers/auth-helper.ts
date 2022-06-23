export const autheader = () => {
  const user = JSON.parse(localStorage.getItem("admin") || "");
  if (user && user.token && user !== "") {
    // return { Authorization: "Bearer " + user.token };
    return user.token;
  } else {
    return null;
  }
};
