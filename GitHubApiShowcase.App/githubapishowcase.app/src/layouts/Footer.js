import { Link } from 'react-router-dom'
import { FaFacebook, FaInstagram, FaLinkedin, FaSquareGithub } from 'react-icons/fa6';

import './Footer.css'

function Footer() {

    var currentYear = new Date().getFullYear();

    return (
        <footer className='footer'>
            <ul className='social-list'>
                <li><Link to='https://www.facebook.com/' target='_blank'><FaFacebook /></Link></li>
                <li><Link to='https://www.instagram.com/' target='_blank'><FaInstagram /></Link></li>
                <li><Link to='https://www.linkedin.com/' target='_blank'><FaLinkedin /></Link></li>
                <li><Link to='https://github.com/' target='_blank'><FaSquareGithub /></Link></li>
            </ul>
            <p className='copy-right'>
                <span>GitHub Showcase</span> &copy; {currentYear}
            </p>
        </footer>
    );
}

export default Footer