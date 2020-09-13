import React from 'react';
import {
    Button,
    Form,
    FormGroup,
    Label,
    Input,
    FormText,
    Row,
    Col,
  } from "reactstrap";
const input = ( props ) => {
    let inputElement = null;
    const inputClasses = [];

    if (props.invalid && props.shouldValidate && props.touched) {
      //  inputClasses.push(classes.Invalid);
    }

    switch ( props.elementType ) {
        case ( 'input' ):
            inputElement = <Input
                className={inputClasses.join(' ')}
               //type= {...props.elementConfig.type}
                value={props.value}
               // placeholder={...props.elementConfig.placeholder}
                onChange={props.changed} />;
            break;
        case ( 'textarea' ):
            inputElement = <textarea
                className={inputClasses.join(' ')}
                {...props.elementConfig}
                value={props.value}
                onChange={props.changed} />;
            break;
        case ( 'select' ):
            inputElement = (
                <select
                    className={inputClasses.join(' ')}
                    value={props.value}
                    onChange={props.changed}>
                    {props.elementConfig.options.map(option => (
                        <option key={option.value} value={option.value}>
                            {option.displayValue}
                        </option>
                    ))}
                </select>
            );
            break;
        default:
            inputElement = <Input
                className={inputClasses.join(' ')}
                {...props.elementConfig}
                value={props.value}
                onChange={props.changed} />;
    }

    return (
        <FormGroup>
        <Label for="exampleEmail">Email</Label>
            <Label>{props.label}</Label>
            {inputElement}
        </FormGroup>
    );

};

export default input;