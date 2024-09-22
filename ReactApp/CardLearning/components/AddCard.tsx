import React, { useState } from 'react';
import { Card } from '../types';

interface AddCardProps {
  onAddCard: (card: Card) => void;
}

const AddCard: React.FC<AddCardProps> = ({ onAddCard }) => {
  const [word, setWord] = useState('');
  const [translation, setTranslation] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (word && translation) {
      const newCard = { id: Date.now(), word, translation };
      onAddCard(newCard);
      setWord('');
      setTranslation('');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        value={word}
        onChange={(e) => setWord(e.target.value)}
        placeholder="Слово на иностранном"
      />
      <input
        type="text"
        value={translation}
        onChange={(e) => setTranslation(e.target.value)}
        placeholder="Перевод"
      />
      <button type="submit">Добавить</button>
    </form>
  );
};

export default AddCard;
