const _apiUrl = "/api/orderRose";

export const newOrderRose = (orderRose, userId) => {
    return fetch(`${_apiUrl}/newOrderRose/?userId=${userId}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(orderRose),
    }).then(response => {
        if (!response.ok) {
          return response.text().then(text => {
            return Promise.reject(text);
          });
        }   
      });
  };