import { DeckCollection } from '../Entities/DeckCollection';
import { Deck } from '../Entities/Deck';

describe('DeckCollection', () => {
    let deckCollection: DeckCollection;
    let deck1: Deck;
    let deck2: Deck;

    beforeEach(() => {
        deckCollection = new DeckCollection();
        deck1 = new Deck('Deck 1');
        deck2 = new Deck('Deck 2');
    });

    it('should add a deck to the collection', () => {
        deckCollection.addDeck(deck1);
        expect(deckCollection.getDeck('Deck 1')).toBe(deck1);
    });

    it('should remove a deck from the collection by name', () => {
        deckCollection.addDeck(deck1);
        deckCollection.addDeck(deck2);

        deckCollection.removeDeck('Deck 1');

        expect(deckCollection.getDeck('Deck 1')).toBeNull();
        expect(deckCollection.getDeck('Deck 2')).toBe(deck2);
    });

    it('should get a deck by name', () => {
        deckCollection.addDeck(deck1);
        const deck = deckCollection.getDeck('Deck 1');
        expect(deck).toBe(deck1);
    });

    it('should return null if deck not found by name', () => {
        const deck = deckCollection.getDeck('Non-existent Deck');
        expect(deck).toBeNull();
    });
});
