import { createDeckCollection, addDeck, removeDeck, getDeck } from '../Entities/DeckCollection';
import { createDeck } from '../Entities/Deck';

describe('DeckCollection', () => {
    it('should create a new deck collection', () => {
        const collection = createDeckCollection();
        expect(collection.decks).toHaveLength(0);
    });

    it('should add a deck to the collection', () => {
        let collection = createDeckCollection();
        const deck = createDeck('Test Deck');

        collection = addDeck(collection, deck);
        expect(collection.decks).toHaveLength(1);
        expect(collection.decks[0].deckName).toBe('Test Deck');
    });

    it('should remove a deck by name', () => {
        let collection = createDeckCollection();
        const deck1 = createDeck('Deck 1');
        const deck2 = createDeck('Deck 2');

        collection = addDeck(collection, deck1);
        collection = addDeck(collection, deck2);

        collection = removeDeck(collection, 'Deck 1');
        expect(collection.decks).toHaveLength(1);
        expect(collection.decks[0].deckName).toBe('Deck 2');
    });

    it('should get a deck by name', () => {
        let collection = createDeckCollection();
        const deck = createDeck('Test Deck');
        collection = addDeck(collection, deck);

        const foundDeck = getDeck(collection, 'Test Deck');
        expect(foundDeck?.deckName).toBe('Test Deck');
    });
});
