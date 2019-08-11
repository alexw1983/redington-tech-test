import React from 'react';

export function FormNotes() {
    return (<div>
        <p>
            Input two probabilites A and B (note: must be between 0 and 1), select a calculation type and hit Submit.
        </p>
        <p>
            <strong>Combine</strong> calculates the probability of both A and B i.e. P(A)P(B)
        </p>
        <p>
            <strong>Either</strong> calculates the probability of either A and B i.e. P(A) + P(B) - P(A)P(B)
        </p>
    </div>);
}

