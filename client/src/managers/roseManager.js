const _apiUrl = "/api/rose";

export const getRoses = () => {
    return fetch(_apiUrl).then((res) => res.json());
  };
  