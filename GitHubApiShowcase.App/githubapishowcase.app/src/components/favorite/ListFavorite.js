import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { useEffect, useState } from 'react';

import ToastAlert from '../../layouts/ToastAlert';

import './ListFavorite.css'

const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
      backgroundColor: 'chocolate',
      color: theme.palette.common.black,
    },
    [`&.${tableCellClasses.body}`]: {
      fontSize: 14,
    },
  }));
  
  const StyledTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
      backgroundColor: theme.palette.action.hover,
    },
    // hide last border
    '&:last-child td, &:last-child th': {
      border: 0,
    },
  }));

function ListFavorite() {

    const [repositories, setRepositories] = useState([]);
    const [message, setMessage] = useState('');
    const [severity, setSeverity] = useState('');

    function Alert(message, severity){
        setSeverity(severity);
        setMessage(message);
    }

    useEffect(() => {
        fetch(`http://localhost:8081/api/GitHubAPIShowcase/GetFavorites`, {
            method: 'GET',
            headers: {
                'content-type': 'application/json'
            }
        })
        .then((resp) => resp.json())
        .then((data) => { 
            console.log(data);
            setRepositories(data.items);
            Alert("Lista de favoritos carregada com sucesso.", "success");
        })
        .catch((err) => {
            console.log(err);
            Alert("Ocorreu um erro ao carregar a lista.", "error");
        });
    }, []);


    return (
        <div className='list-content'>
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <StyledTableCell>Proprietário</StyledTableCell>
                        <StyledTableCell>Nome</StyledTableCell>
                        <StyledTableCell>Descrição</StyledTableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {repositories.map((repository) => (
                        <StyledTableRow
                            key={repository.id}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <StyledTableCell component="th" scope="row">{repository.owner}</StyledTableCell>
                            <StyledTableCell>{repository.name}</StyledTableCell>
                            <StyledTableCell>{repository.description}</StyledTableCell>
                        </StyledTableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
        <ToastAlert message={message} severity={severity}></ToastAlert>
        </div>
    );
}

export default ListFavorite