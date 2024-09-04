import { Routes, Route } from 'react-router-dom';
import { createTheme, ThemeProvider } from '@mui/material/styles';

import Navbar from './layouts/Navbar';
import Footer from './layouts/Footer';
import Container from './layouts/Container';

import Home from './pages/Home'
import Favorite from './pages/Favorite'

import './App.css';
import Repository from './pages/Repository';

const theme = createTheme({
  components: {
    MuiTextField: {
      styleOverrides: {
        root: {
          '& .MuiInputLabel-root.Mui-focused': {
            color: 'black',
          },
          '& .css-r5in8e-MuiInputBase-root-MuiInput-root::after': {
            borderColor: 'black',
          }
        },
      },
    },
  },
});

function App() {
  return (
    <ThemeProvider theme={theme}>
      <Navbar />
      <Container customClass='min-height'>
        <Routes>
          <Route path='/' element={<Home />} />
          <Route path='/favorites' element={<Favorite />} />
          <Route path='/repository/:owner/:id' element={<Repository />}/>
        </Routes>
      </Container>
      <Footer />
    </ThemeProvider>
  )
}

export default App;
