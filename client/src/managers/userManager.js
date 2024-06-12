const _apiUrl = "/api/userProfile";


export const getUserById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};
