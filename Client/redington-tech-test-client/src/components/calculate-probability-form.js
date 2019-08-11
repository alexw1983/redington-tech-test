import React from 'react';

export class CalculateProbabilityForm extends React.Component {
    render() {
        return (<form onSubmit={this.props.onSubmit}>
            <div className="form-group">
                <label htmlFor="A">A:</label>
                <input
                    type="text"
                    name='A'
                    className="form-control"
                    value={this.props.value.A}
                    onChange={this.props.onChange}
                />
            </div>
            <div className="form-group">
                <label htmlFor="B">B:</label>
                <input
                    type="text"
                    name='B'
                    className="form-control"
                    value={this.props.value.B}
                    onChange={this.props.onChange}
                />
            </div>
            <div className="form-group">
                <label htmlFor="calcType">Calculation Type</label>
                <select
                    className="form-control"
                    name="calcType"
                    value={this.props.value.calcType}
                    onChange={this.props.onChange}>
                    <option value="combine">Combine</option>
                    <option value="either">Either</option>
                </select>
            </div>

            <div className="form-group">
                <button
                    type='submit'
                    className="btn btn-primary">
                    Submit
          </button>
            </div>
        </form>
        );
    }
}