import { useEffect, useState } from 'react';
import { GoRepo } from "react-icons/go";
import List from '@mui/material/List';
import ListItem from '@mui/material/ListItem';
import ListItemText from '@mui/material/ListItemText';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListSubheader from '@mui/material/ListSubheader';

import './ListRepository.css'

function ListRepository({ repositories }) {

    const [subheaderText, setSubheaderText] = useState('');

    useEffect(() => {
        if (repositories.length > 0) {
            setSubheaderText(`Lista de repositórios: (${repositories.length})`);
        } else {
            setSubheaderText('');
        }
    }, [repositories]);

    return (
        <List
            sx={{ width: '100%', maxWidth: 360, bgcolor: 'background.paper' }}
            component="ul"
            aria-labelledby="nested-list-subheader"
            subheader={
                <ListSubheader component="li" id="nested-list-subheader" >
                     {subheaderText}
                </ListSubheader>
            }
        >
            {repositories.map((repository, index) => (
                <ListItem
                    key={repository.id}
                    disablePadding
                >
                    <ListItemButton href={`/Repository/${repository.owner}/${repository.id}`}>
                        <ListItemIcon>
                            <GoRepo size={32}/>
                        </ListItemIcon>
                        <ListItemText 
                            primary={`${index} - ${repository.name}`} 
                            secondary={repository.owner} 
                        />
                    </ListItemButton>
                </ListItem>
            ))}
        </List>
    );
}

export default ListRepository