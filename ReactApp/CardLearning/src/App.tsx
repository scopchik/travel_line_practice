import React from 'react';
import { Container, Typography, Box, ThemeProvider } from '@mui/material';
import Deck from '../components/Deck';
import theme from '../styles/theme';
import { Card as CardType } from '../types';

const initialCards: CardType[] = [
  { id: 1, word: 'Hello', translation: 'Привет' },
  { id: 2, word: 'World', translation: 'Мир' },
  { id: 3, word: 'Learn', translation: 'Учить' },
  { id: 4, word: 'React', translation: 'Реакт' },
];

const App: React.FC = () => {
  return (
    <ThemeProvider theme={theme}>
      <Container maxWidth="sm">
        <Box sx={{ textAlign: 'center', marginTop: '20px' }}>
          <Typography variant="h4" gutterBottom>
            Flashcards App
          </Typography>
          <Deck initialCards={initialCards} />
        </Box>
      </Container>
    </ThemeProvider>
  );
};

export default App;
