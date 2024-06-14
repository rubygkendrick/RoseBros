const _apiUrl = "/api/color";

export const getColors = () => {
  return fetch(_apiUrl).then((res) => res.json());
};
