
export class CalculationService {
  calculateProbability = (calcType, A, B) => {

    const root = 'https://aw-redington.azurewebsites.net/api/probability-calculations';
    const url = calcType === "combine" ? `${root}/combine` : `${root}/either`;

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
