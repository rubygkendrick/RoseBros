const _apiUrl = "/api/order";

export const newOrder = (orderRose, userId) => {
    return fetch(`${_apiUrl}/newOrder/?userId=${userId}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify( {orderRose, userId} ),
    });
  };
