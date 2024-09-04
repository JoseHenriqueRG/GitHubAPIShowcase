import './Input.css'

import { TextField } from '@mui/material'

function Input({ type, text, name, placeholder, handleOnChange, value}){
    return (
        <div className='form-control'>
            <TextField
                type={type}
                id={name}
                label={text}
                variant="standard"
                name={text} 
                value={value} 
                onChange={handleOnChange}  
                placeholder={placeholder} 
                />
        </div>
    );
}

export default Input