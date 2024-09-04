import { useState } from 'react';
import SearchRepository from '../components/repository/SearchRepository';
import ListRepository from '../components/repository/ListRepository';

import './Home.css'

function Home() {

    const [repositories, setRepositories] = useState([]);

    return <>
        <section className="home-container">
            <h1>Bem-vindo ao <span>GitHub Showcase</span></h1>
            <p>Pesquise repositórios no GitHub</p>
            <SearchRepository setRepositories={setRepositories} />
            <ListRepository repositories={repositories} />
        </section>
    </>
}

export default Home 