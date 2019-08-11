import { CONFIG } from '../app-config';

export class CalculationService {
  calculateProbability = (calcType, A, B) => {

    const url = calcType === "combine" ? `${CONFIG.API_ROOT}/combine` : `${CONFIG.API_ROOT}/either`;

    return fetch(url, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        "A": A,
        "B": B
      }),
    })
      .then((response) => {
        return response.json()
      })
      .then((responseJson) => {
        return responseJson;
      })
      .catch((error) => {
        console.error(error);
      });
  }
}
