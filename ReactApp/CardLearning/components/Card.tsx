import React, { useState } from 'react';
import { Card as CardType } from '../types';

interface CardProps {
  card: CardType;
  onLearned: (cardId: number) => void;
}

const Card: React.FC<CardProps> = ({ card, onLearned }) => {
  const [isFlipped, setIsFlipped] = useState(false);

  const flipCard = () => {
    setIsFlipped(!isFlipped);
  };

  const markAsLearned = () => {
    onLearned(card.id);
  };

  return (
    <div className="card">
      {/* Если карточка перевернута, показываем перевод, иначе - иностранное слово */}
      <div onClick={flipCard} style={styles.cardContent}>
        {isFlipped ? (
          <p>{card.translation}</p>
        ) : (
          <p>{card.word}</p>
        )}
      </div>

      {/* Кнопка для пометки карточки как выученной */}
      <button onClick={markAsLearned} style={styles.learnedButton}>
        Я выучил это слово
      </button>
    </div>
  );
};

const styles = {
  cardContent: {
    border: '1px solid #ccc',
    padding: '20px',
    textAlign: 'center' as const,
    cursor: 'pointer',
    width: '200px',
    height: '150px',
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    fontSize: '18px',
    backgroundColor: '#f9f9f9',
    marginBottom: '10px',
    borderRadius: '5px',
  },
  learnedButton: {
    padding: '10px 20px',
    backgroundColor: '#4CAF50',
    color: 'white',
    border: 'none',
    borderRadius: '5px',
    cursor: 'pointer',
  },
};

export default Card;
