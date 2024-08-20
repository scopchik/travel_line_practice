import { User } from '../Entities/User';
import { Deck } from '../Entities/Deck';

describe('User', () => {
    let user: User;
    let deck: Deck;

    beforeEach(() => {
        user = new User('testUser', 'password', 'test@example.com');
        deck = new Deck('Test Deck');
    });

    it('should add a new deck', () => {
        user.addDeck(deck);
        expect(user.decks.length).toBe(1);
        expect(user.decks[0].deckName).toBe('Test Deck');
    });

    it('should remove a deck', () => {
        user.addDeck(deck);
        user.removeDeck('Test Deck');
        expect(user.decks.length).toBe(0);
    });
});
