const _apiUrl = "/api/order";

export const choreCompleted = (orderRose, userId) => {
    return fetch(`${_apiUrl}/new/?userId=${userId}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify( {orderRose, userId} ),
    });
  };
