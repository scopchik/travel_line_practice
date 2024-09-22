import React, { useState } from 'react';
import { Box, Typography } from '@mui/material';
import { Card as CardType } from '../types';
import './CardComponent.css'; 

interface CardComponentProps {
  card: CardType;
}

const CardComponent: React.FC<CardComponentProps> = ({ card }) => {
  const [flipped, setFlipped] = useState(false);

  const handleFlip = () => {
    setFlipped(!flipped);
  };

  return (
    <Box
      className={`card ${flipped ? 'flipped' : ''}`}
      onClick={handleFlip}
      sx={{
        width: '300px',
        height: '200px',
        perspective: '1000px',
        margin: '0 auto',
      }}
    >
      <Box className="card-inner" sx={{ position: 'relative', width: '100%', height: '100%' }}>
        {/* Лицевая сторона */}
        <Box className="card-face card-front" sx={{ ...cardFaceStyles }}>
          <Typography variant="h5" sx={{ color: 'black' }}>{card.word}</Typography>
        </Box>

        {/* Обратная сторона */}
        <Box className="card-face card-back" sx={{ ...cardFaceStyles }}>
          <Typography variant="h5" sx={{ color: 'black' }}>{card.translation}</Typography>
        </Box>
      </Box>
    </Box>
  );
};

const cardFaceStyles = {
  position: 'absolute',
  width: '100%',
  height: '100%',
  display: 'flex',
  justifyContent: 'center',
  alignItems: 'center',
  backfaceVisibility: 'hidden',
  borderRadius: '10px',
  backgroundColor: 'white',
  boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)',
  cursor: 'pointer',
};

export default CardComponent;
