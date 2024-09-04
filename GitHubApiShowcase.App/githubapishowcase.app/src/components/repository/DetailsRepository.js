import { useEffect, useState } from 'react';
import Box from '@mui/material/Box';
import { Card, CardContent, Typography } from '@mui/material';

import ToastAlert from '../../layouts/ToastAlert';
import Loading from '../../layouts/Loading';
import ButtonLink from '../../layouts/ButtonLink';

import './DetailsRepository.css'
import Button from '../../layouts/Button';

function DetailsRepository({owner, id}) {

    const [btnDisabled, setBtnDisabled] = useState(false);
    const [repository, serRepository] = useState({});
    const [severity, setSeverity] = useState("");
    const [message, setMessage] = useState("");
    const [loading, setLoading] = useState(true);

    function Alert(severity, message) {
        setSeverity(severity);
        setMessage(message);
    }

    function addFavorite(e){
        e.preventDefault();

        if(repository.id === undefined) return;

        const rep = {
            owner: repository.owner,
            name: repository.name,
            description: repository.description
        };
        
        fetch(`http://localhost:8081/api/GitHubAPIShowcase/SaveFavorite`, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(rep)
        })
        .then((resp) => 
            resp.json()
        )
        .then((data) => {  
            console.log(data);
            setBtnDisabled(true);
            Alert("success", "Repositório adicionado aos favoritos!");
        })
        .catch((err) => { 
            console.log("Erro ao favoritar o repositório: ", err.message || err);
            Alert("error", err.message || "Ocorreu um erro ao processar sua solicitação.");        
        })
    }

    useEffect(() => {
        fetch(`http://localhost:8081/api/GitHubAPIShowcase/GetRepositoryByOwnerAndId?owner=${owner}&id=${id}`, {
            method: 'GET',
            headers: {
                'content-type': 'application/json'
            }
        })
            .then((res) => res.json())
            .then((data) => {
                console.log(data.item);
                serRepository(data.item);
                Alert("success", "Detalhes do repositório carregado com sucesso!");
                setLoading(false);
            })
            .catch((err) => {
                console.log("Erro ao consultar a API do GitHub: " + err);
                Alert("error", "Ocorreu um erro ao carregar os detalhes do repositório. Por favor, tente novamente mais tarde.");
                setLoading(false);
            });
    }, [owner, id]);

    return (
        <>
            {loading && (
                <Loading />
            )}
            {repository.id !== undefined &&
                (
                    <Box component="section" className='box-content'>
                        <Card variant='outline' className='card-content'>
                            <CardContent>
                                <Typography variant="h5" component="div">
                                    {repository.fullName}
                                </Typography>
                                <Typography variant="body1">
                                    {repository.description}
                                </Typography>
                                <Typography variant="body2">
                                    Proprietário: {repository.owner}
                                </Typography>
                                <ButtonLink to={repository.htmlUrl} text='Acesse no GitHub' />
                                <Button type="button" text="Favoritar" eventOnClick={addFavorite} disabled={btnDisabled}/>
                            </CardContent>
                        </Card>
                    </Box>
                )
            }
            {
                <ToastAlert
                    message={message}
                    severity={severity}
                />
            }
        </>
    );
}

export default DetailsRepository