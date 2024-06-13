const _apiUrl = "/api/rose";

export const getRoses = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getRoseById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const addRose  = (newRose) => {
  return fetch(`${_apiUrl}/add`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newRose),
  }).then((res) => res.json());
};