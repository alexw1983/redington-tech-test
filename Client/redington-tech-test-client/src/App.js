import React from 'react';

class App extends React.Component {
  constructor() {
    super();
    this.state = { A: null, B: null, CALC: null, calcType: "combine" };
  }

  hitAPI() {

    //const root = 'http://localhost:5000/api/probability-calculations';

    const root = 'https://aw-redington.azurewebsites.net/api/probability-calculations';
    const url = this.state.calcType === "combine" ? `${root}/combine` : `${root}/either`;

    return fetch(url, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        "A": this.state.A,
        "B": this.state.B
      }),
    })
      .then((response) => {
        return response.json()
      })
      .then((responseJson) => {
        this.setState({
          CALC: responseJson
        });
        //return responseJson;
      })
      .catch((error) => {
        console.error(error);
      });
  }

  mySubmitHandler = (event) => {
    event.preventDefault();
    this.hitAPI();
  }

  myChangeHandler = (event) => {

    let nam = event.target.name;
    let val = event.target.value;

    this.setState({ [nam]: val });
  }

  render() {
    return <div className="container">
      <div className="pb-2 mt-4 mb-2 border-bottom">
        <h1>Redington Tech Test</h1>
      </div>

      <div className="card card-primary">
        <div className="card-header">
          <h3>
            Probability Calculator
          </h3>
        </div>
        <div className="card-body">
          <div className="row">
            <div className="col-md-6 col-xs-12">
              <form onSubmit={this.mySubmitHandler}>
                <div className="form-group">
                  <label htmlFor="A">A:</label>
                  <input
                    type="text"
                    name='A'
                    className="form-control"
                    onChange={this.myChangeHandler}
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="B">B:</label>
                  <input
                    type="text"
                    name='B'
                    className="form-control"
                    onChange={this.myChangeHandler}
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="calcType">Type</label>
                  <select
                    className="form-control"
                    name="calcType"
                    value={this.state.calcType}
                    onChange={this.myChangeHandler}>
                    <option value="combine">Combine</option>
                    <option value="either">Either</option>
                  </select>
                </div>

                <div className="form-group">
                  <button
                    type='submit'
                    className="btn btn-primary" >
                    Submit
                  </button>
                </div>
              </form>
            </div>
            <div className="col-md-6 col-xs-12">
              <div className="card .bg-info">
                <div className="card-header">
                  Result
                </div>
                <div className="card-body">
                  {this.state.CALC}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  };
}

export default App;
