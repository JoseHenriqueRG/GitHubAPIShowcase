import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';
import Slide from '@mui/material/Slide';

import './ToastAlert.css'
import { useEffect, useState } from 'react';

function ToastAlert({ message, severity }) {
    const vertical = 'bottom';
    const horizontal = 'center';
    const [open, setOpen] = useState(true);

    function SlideTransition(props) {
        return <Slide {...props} direction="up" />;
    }

    useEffect(() => {
        if(!message){
            setOpen(false);
        }
        setOpen(true);
    }, [message]);

    const handleOnClose = () => {
        setOpen(false);
    };

    return (
        <Snackbar
            anchorOrigin={{ vertical, horizontal }}
            open={open}
            onClose={handleOnClose}
            TransitionComponent={SlideTransition}
            key={vertical + horizontal}
            autoHideDuration={5000}
        >
            <Alert
                severity={severity}
                onClose={handleOnClose}
                sx={{ width: '100%' }}
            >
                {message}
            </Alert>
        </Snackbar>
    );
}

export default ToastAlert