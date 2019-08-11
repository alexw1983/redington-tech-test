import React from 'react';

export const FormErrors = ({ formErrors }) =>
    <div>
        {Object.keys(formErrors).map((fieldName, i) => {
            if (formErrors[fieldName].length > 0) {
                return (
                    <div key={i} className='alert alert-danger'>
                        <p key={i}>{fieldName} {formErrors[fieldName]}</p>
                    </div>
                )
            } else {
                return '';
            }
        })}
    </div>