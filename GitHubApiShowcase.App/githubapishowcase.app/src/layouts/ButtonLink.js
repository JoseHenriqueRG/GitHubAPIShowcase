import { Link } from 'react-router-dom'
import './ButtonLink.css'

function ButtonLink({to, text}){
    return(
        <Link to={to} className='btn'>{text}</Link>
    );
}

export default ButtonLink