import { Link } from 'react-router-dom'

import Container from './Container';

import './Navbar.css'


function Navbar() {
    return (
        <nav className='navbar'>
            <Container>
                <Link to='/'>
                    <img src='https://via.placeholder.com/50' alt='logo' />
                </Link>
                <ul className='list'>
                    <li className='item'><Link to='/'>Home</Link></li>
                    <li className='item'><Link to='/favorites'>Favoritos</Link></li>
                </ul>
            </Container>
        </nav>
    );
}

export default Navbar