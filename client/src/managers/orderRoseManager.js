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


  export const updateQuantity = (qty, roseId , userId) => {
    return fetch(`${_apiUrl}/updateQuantity?qty=${qty}&roseId=${roseId}&userId=${userId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
    })
  };

  export const deleteOrderRose = (roseId, orderId) => {
    return fetch(`${_apiUrl}/delete?roseId=${roseId}&orderId=${orderId}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
      },
    });
  };
  