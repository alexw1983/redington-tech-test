import React from 'react';
import logo from './logo.svg';
import './App.css';



class App extends React.Component {
  constructor() {
    super();
    this.state = { A: 0, B: 0, CALC: 0, myType: "combine" };

    this.hitAPI();
  }

  hitAPI() {

    const url = this.state.myType === "combine" ?
      'http://localhost:5000/api/probability-calculations/combine' :
      'http://localhost:5000/api/probability-calculations/either';
    //console.log('got here');
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
    return <div className="App">
      <h1>YOUR MUM</h1>
      <header className="App-header">
        <p>
          CALC = {this.state.CALC}
        </p>

        <form onSubmit={this.mySubmitHandler}>
          <h1>Hello</h1>
          <p>A:</p>
          <input
            type="text" name='A'
            onChange={this.myChangeHandler}
          />

          <p>B:</p>
          <input
            type="text" name='B'
            onChange={this.myChangeHandler}
          />
          <p>type</p>

          <select name="myType" value={this.state.myType} onChange={this.myChangeHandler}>
            <option value="combine">Combine</option>
            <option value="either">Either</option>

          </select>
          <p></p>
          <input
            type='submit'
          />
        </form>

        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  };
}

export default App;
