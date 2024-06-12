const _apiUrl = "/api/order";

export const newOrder = (userId) => {
  return fetch(`${_apiUrl}/newOrder/?userId=${userId}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userId),
  }).then((res) => res.json());
};

export const getActiveOrderByUserId = (userId) => {
  return fetch(`${_apiUrl}/active/${userId}`)
    .then(response => {
      if (!response.ok) {
        return response.text().then(text => {
          return Promise.reject(text);
        });
      }
      // Return JSON data when response is okay
      return response.json();
    });
};

export const completeOrder = (orderId) => {
  return fetch(`${_apiUrl}/complete/${orderId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
  })
};