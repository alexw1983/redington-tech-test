import React from 'react';

import { CalculationService } from './services/calculation-service';
import { AppHeader } from './components/app-header';
import { ResultBox } from './components/result-box';
import { FormErrors } from './components/form-errors';
import { FormNotes } from './components/form-notes';

class App extends React.Component {

  constructor() {
    super();
    this.service = new CalculationService();
    this.state = {
      A: 0,
      B: 0,
      calcResult: 0,
      calcType: "combine",
      formErrors: { A: '', B: '' },
      aIsValid: true,
      bIsValid: true,
      formValid: true
    };
  }

  handleSubmission = (event) => {
    event.preventDefault();

    this.service
      .calculateProbability(this.state.calcType, this.state.A, this.state.B)
      .then(response => {
        this.setState({
          calcResult: response
        });
      })
  }

  handleChange = (event) => {
    event.preventDefault();

    let nam = event.target.name;
    let val = event.target.value;

    this.setState({ [nam]: val }, () => { this.validateField(nam, val) });
  }

  probabilityIsValid(value) {
    return value >= 0 && value <= 1;
  }

  validateField(fieldName, value) {
    let fieldValidationErrors = this.state.formErrors;
    let aIsValid = this.state.aIsValid;
    let bIsValid = this.state.bIsValid;

    const message = " => must be between 0 and 1";

    switch (fieldName) {
      case 'A':
        aIsValid = this.probabilityIsValid(value);
        fieldValidationErrors.A = aIsValid ? '' : message;
        break;
      case 'B':
        bIsValid = this.probabilityIsValid(value);
        fieldValidationErrors.B = bIsValid ? '' : message;
        break;
      default:
        break;
    }

    this.setState({
      formErrors: fieldValidationErrors,
      aIsValid: aIsValid,
      bIsValid: bIsValid
    }, this.validateForm);
  }

  validateForm() {
    this.setState({ formValid: this.state.aIsValid && this.state.bIsValid });
  }

  errorClass(error) {
    return (error.length === 0 ? '' : 'alert aelrt-danger');
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
              <FormErrors formErrors={this.state.formErrors} />
              <form onSubmit={this.handleSubmission}>


                <div className="form-group">
                  <label htmlFor='A'>Input A</label>
                  <input
                    type="text"
                    name="A"
                    className="form-control"
                    value={this.state.A}
                    onChange={this.handleChange}
                  />
                </div>

                <div className="form-group">
                  <label htmlFor='B'>Input B</label>
                  <input
                    type="text"
                    name="B"
                    className="form-control"
                    value={this.state.B}
                    onChange={this.handleChange}
                  />
                </div>

                <div className="form-group">
                  <label htmlFor="calcType">Calculation Type</label>
                  <select
                    className="form-control"
                    name="calcType"
                    value={this.state.calcType}
                    onChange={this.handleChange}>
                    <option value="combine">Combine</option>
                    <option value="either">Either</option>
                  </select>
                </div>

                <div className="form-group">
                  <button
                    type='submit'
                    className="btn btn-primary"
                    disabled={!this.state.formValid}>
                    Submit
                  </button>
                </div>
              </form>
              <FormNotes></FormNotes>
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

