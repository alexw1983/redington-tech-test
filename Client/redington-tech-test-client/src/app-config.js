// By default I am pointing this at the dev instance
// To change environment simply comment out which path you want.
// If I had more time I'd have this read from environment config but this will do for the tech test

// local
// const api_root = 'http://localhost:5000/api/probability-calculations';

// dev
const api_root = 'https://aw-redington.azurewebsites.net/api/probability-calculations';

export const CONFIG = {
    API_ROOT: api_root
};