const _apiUrl = "/api/order";

export const newOrder = (userId) => {
    return fetch(`${_apiUrl}/newOrder/?userId=${userId}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify( userId ),
    }).then((res) => res.json());
  };
