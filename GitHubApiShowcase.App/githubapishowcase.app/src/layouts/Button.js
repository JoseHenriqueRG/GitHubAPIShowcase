import { Button as Btn } from '@mui/material';

import './Button.css'

function Button({type, text, size = 'larger', eventOnClick, disabled = false }){
    return (
        <Btn 
            variant="contained" 
            className='btn' 
            type={type} 
            onClick={eventOnClick} 
            size={size}
            disabled={disabled}
        >{text}</Btn>
    );
}

export default Button