const _apiUrl = "/api/habit";

export const getHabits = () => {
  return fetch(_apiUrl).then((res) => res.json());
};
