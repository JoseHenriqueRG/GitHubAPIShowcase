import { useState } from 'react';

import Input from '../forms/Input';

import Loading from '../../layouts/Loading';
import Button from '../../layouts/Button';
import ToastAlert from '../../layouts/ToastAlert';

import './SearchRepository.css'

function SearchRepository({ setRepositories }) {

    const page = 1;
    const perPage = 100;
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState("");
    const [term, setTerm] = useState("");
    const [loading, setLoading] = useState(false);

    function Alert(severity, message){
        setSeverity(severity);
        setMessage(message);
    }

    function searchRepository(e) {
        if(!term){
            return
        }
        e.preventDefault();
        setLoading(true);
        fetch(`http://localhost:8081/api/GitHubAPIShowcase/SearchRepositories?term=${term}&page=${page}&perPage=${perPage}`, {
            method: 'GET',
            headers: {
                'content-type': 'application/json'
            }
        })
            .then((res) => res.json())
            .then((data) => {
                setRepositories(data.item.repositories);
                Alert("success", "Lista carregada com sucesso!")
                setLoading(false);
            })
            .catch((err) => {
                console.log("Erro ao consultar a API do GitHub: " + err);
                Alert("error", "Ocorreu um erro ao carregar a lista. Por favor, tente novamente mais tarde.");
                setLoading(false);
            });
    }

    return (
        <>
            <div className='form'>
                <Input
                    type="search"
                    text="Repositório"
                    name="term"
                    value={term}
                    handleOnChange={(e) => setTerm(e.target.value)}
                />
                <div className='form-btn'>
                    <Button type="button" text="Pesquisar" eventOnClick={searchRepository} />
                </div>

                {loading && (
                    <Loading />
                )}
            </div>
            {
                message.length > 0 && severity.length > 0 ?
                    (
                        <ToastAlert 
                            message={message} 
                            severity={severity} 
                        />
                    ) : ""
            }
        </>);
}

export default SearchRepository