import React, { useState } from 'react';
import { TextField, Button, Stack, Box, Typography } from '@mui/material';
import { Card as CardType } from '../types';

interface AddCardFormProps {
  onAddCard: (newCard: CardType) => void;
  nextCardId: number;
}

const AddCardForm: React.FC<AddCardFormProps> = ({ onAddCard, nextCardId }) => {
  const [word, setWord] = useState('');
  const [translation, setTranslation] = useState('');

  const handleAddCard = () => {
    if (word.trim() && translation.trim()) {
      const newCard: CardType = {
        id: nextCardId,
        word: word.trim(),
        translation: translation.trim(),
      };
      onAddCard(newCard); 
      setWord('');
      setTranslation('');
    }
  };

  return (
    <Stack spacing={2} sx={{ marginTop: '20px' }}>
      {/* Метка для ввода иностранного слова */}
      <Box>
        <Typography variant="body1" gutterBottom>
          Иностранное слово
        </Typography>
        <TextField
          label="Введите слово"
          variant="outlined"
          value={word}
          onChange={(e) => setWord(e.target.value)}
          fullWidth
          sx={{
            backgroundColor: 'white',
          }}
        />
      </Box>

      {/* Метка для ввода перевода на русский */}
      <Box>
        <Typography variant="body1" gutterBottom>
          Перевод на русский
        </Typography>
        <TextField
          label="Введите перевод"
          variant="outlined"
          value={translation}
          onChange={(e) => setTranslation(e.target.value)}
          fullWidth
          sx={{
            backgroundColor: 'white',
          }}
        />
      </Box>

      <Button variant="contained" color="primary" onClick={handleAddCard}>
        Добавить
      </Button>
    </Stack>
  );
};

export default AddCardForm;
