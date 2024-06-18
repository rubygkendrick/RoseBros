const _apiUrl = "/api/rose";

export const getRoses = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getRoseById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const addRose = (formData) => {
  return fetch(`${_apiUrl}/add`, {
    method: "POST",
    body: formData,
  }).then((res) => res.json());
};

export const updateStockStatus = (roseId) => {
  return fetch(`${_apiUrl}/updateStockStatus/${roseId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
  })
};


export const deleteRose = (roseId) => {
  return fetch(`${_apiUrl}/delete/${roseId}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  });
};
