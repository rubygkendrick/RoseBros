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

export const getOrdersForAdmins = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json());
};

export const fulfillOrder = (orderId) => {
  return fetch(`${_apiUrl}/fulfill/${orderId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
  })
};

