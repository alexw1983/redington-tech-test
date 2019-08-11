import React from 'react';

export class ResultBox extends React.Component {
    render() {
        return (<div className="card .bg-info">
            <div className="card-header">
                Result
        </div>
            <div className="card-body">
                {this.props.value}
            </div>
        </div>);
    };
}