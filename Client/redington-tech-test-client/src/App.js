import React from 'react';

import { CalculationService } from './services/calculation-service';
import { AppHeader } from './components/app-header';
import { ResultBox } from './components/result-box';
import { CalculateProbabilityForm } from './components/calculate-probability-form';

class App extends React.Component {

  constructor() {
    super();
    this.service = new CalculationService();
    this.state = {
      A: 0.5,
      B: 0.5,
      calcResult: 0,
      calcType: "combine"
    };
  }

  onSubmit = (event) => {
    event.preventDefault();

    this.service
      .calculateProbability(this.state.calcType, this.state.A, this.state.B)
      .then(response => {
        this.setState({
          calcResult: response
        });
      })
  }

  onChange = (event) => {
    event.preventDefault();

    let nam = event.target.name;
    let val = event.target.value;

    this.setState({ [nam]: val });
  }

  render() {
    return <div className="container">

      <AppHeader></AppHeader>

      <div className="card card-primary">
        <div className="card-header">
          <h3>
            Probability Calculator
          </h3>
        </div>
        <div className="card-body">
          <div className="row">
            <div className="col-md-6 col-xs-12">
              <CalculateProbabilityForm
                onSubmit={(e) => this.onSubmit(e)}
                onChange={(e) => this.onChange(e)}
                value={this.state}>
              </CalculateProbabilityForm>
            </div>
            <div className="col-md-6 col-xs-12">
              <ResultBox value={this.state.calcResult}></ResultBox>
            </div>
          </div>
        </div>
      </div>
    </div>
  };
}

export default App;
