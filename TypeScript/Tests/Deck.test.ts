import { Deck } from '../Entities/Deck';
import { Card } from '../Entities/Card';

describe('Deck', () => {
    let deck: Deck;

    beforeEach(() => {
        deck = new Deck('Test Deck');
    });

    it('should create a deck with a name and creation date', () => {
        expect(deck.deckName).toBe('Test Deck');
        expect(deck.creationDate).toBeInstanceOf(Date);
        expect(deck.cards.length).toBe(0);
    });

    it('should add a card to the deck', () => {
        deck.addCard('Hello', 'Привет');
        expect(deck.cards.length).toBe(1);
        expect(deck.cards[0].foreignWord).toBe('Hello');
    });

    it('should remove a card by id', () => {
        deck.addCard('Hello', 'Привет');
        deck.addCard('Cat', 'Кот');
        const cardId = deck.cards[0].id;

        deck.removeCard(cardId);

        expect(deck.cards.length).toBe(1);
        expect(deck.cards[0].foreignWord).toBe('Cat');
    });

    it('should get a card by id', () => {
        deck.addCard('Hello', 'Привет');
        const cardId = deck.cards[0].id;

        const card = deck.getCard(cardId);
        expect(card).toBeDefined();
        expect(card?.foreignWord).toBe('Hello');
    });

    it('should return null if card not found by id', () => {
        const card = deck.getCard(999);
        expect(card).toBeNull();
    });
});
