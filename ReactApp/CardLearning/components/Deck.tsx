import React, { useState } from 'react';
import { Container, Typography, Button, Stack, Box } from '@mui/material';
import CardComponent from './CardComponent';
import AddCardForm from './AddCardForm';
import { Card as CardType } from '../types';

interface DeckProps {
  initialCards: CardType[];
}

const Deck: React.FC<DeckProps> = ({ initialCards }) => {
  const [cards, setCards] = useState<CardType[]>(initialCards);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [learnedCards, setLearnedCards] = useState<CardType[]>([]);

  const handleAddCard = (newCard: CardType) => {
    setCards([...cards, newCard]);
  };

  const handleNextCard = () => {
    setCurrentIndex((prevIndex) => (prevIndex + 1) % cards.length);
  };

  const handleLearnCard = () => {
    const cardToLearn = cards[currentIndex];
    setLearnedCards([...learnedCards, cardToLearn]);
    setCards(cards.filter((_, index) => index !== currentIndex));
    if (cards.length > 1) {
      setCurrentIndex(currentIndex % (cards.length - 1));
    } else {
      setCurrentIndex(0);
    }
  };

  return (
    <Container maxWidth="sm">
      <Box sx={{ textAlign: 'center', marginTop: '20px' }}>
        <Typography variant="h5" gutterBottom>
          Изучение карточек
        </Typography>
        {cards.length > 0 ? (
          <CardComponent card={cards[currentIndex]} />
        ) : (
          <Typography variant="h6" gutterBottom>
            Все слова выучены!
          </Typography>
        )}
        <Stack direction="row" spacing={2} justifyContent="center" sx={{ marginTop: '20px' }}>
          <Button variant="contained" color="primary" onClick={handleNextCard} disabled={cards.length === 0}>
            Следующее слово
          </Button>
          <Button variant="outlined" color="secondary" onClick={handleLearnCard} disabled={cards.length === 0}>
            Выучить слово
          </Button>
        </Stack>
        <AddCardForm onAddCard={handleAddCard} nextCardId={cards.length + 1} />
      </Box>
    </Container>
  );
};

export default Deck;
