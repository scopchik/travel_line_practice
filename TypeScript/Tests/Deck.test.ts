import { Deck } from '../Entities/Deck';
import { Card } from '../Entities/Card';

describe('Deck', () => {
    let deck: Deck;
    let card: Card;

    beforeEach(() => {
        deck = new Deck('Test Deck');
        card = new Card('Hello', 'Привет');
    });

    it('should add a new card', () => {
        deck.addCard(card);
        expect(deck.cards.length).toBe(1);
        expect(deck.cards[0].foreignWord).toBe('Hello');
    });

    it('should remove a card', () => {
        deck.addCard(card);
        deck.removeCard('Hello');
        expect(deck.cards.length).toBe(0);
    });
});
