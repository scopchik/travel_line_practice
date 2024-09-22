import { createDeck, addCard, removeCard, getCard } from '../Entities/Deck';

describe('Deck', () => {
    it('should create a new deck', () => {
        const deck = createDeck('Test Deck');
        expect(deck.deckName).toBe('Test Deck');
        expect(deck.cards).toHaveLength(0);
        expect(deck.nextCardId).toBe(1);
    });

    it('should add a card to the deck', () => {
        let deck = createDeck('Test Deck');
        deck = addCard(deck, 'hello', 'привет');
        expect(deck.cards).toHaveLength(1);
        expect(deck.cards[0].foreignWord).toBe('hello');
    });

    it('should remove a card from the deck', () => {
        let deck = createDeck('Test Deck');
        deck = addCard(deck, 'hello', 'привет');
        deck = addCard(deck, 'bye', 'пока');

        deck = removeCard(deck, deck.cards[0].id);
        expect(deck.cards).toHaveLength(1);
        expect(deck.cards[0].foreignWord).toBe('bye');
    });

    it('should get a card by id', () => {
        let deck = createDeck('Test Deck');
        deck = addCard(deck, 'hello', 'привет');
        const card = getCard(deck, deck.cards[0].id);
        expect(card?.foreignWord).toBe('hello');
    });
});
