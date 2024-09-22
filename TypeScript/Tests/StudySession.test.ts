import { createStudySession, takeCard, submitTranslation } from '../Entities/StudySession';
import { createDeck, addCard } from '../Entities/Deck';

describe('StudySession', () => {
    it('should create a new study session with a shuffled deck', () => {
        let deck = createDeck('Test Deck');
        deck = addCard(deck, 'apple', 'яблоко');
        deck = addCard(deck, 'orange', 'апельсин');

        const session = createStudySession(deck);
        expect(session.deck.cards).toHaveLength(2);
        expect(session.currentCard).toBe(null);
    });

    it('should take the first card from the deck', () => {
        let deck = createDeck('Test Deck');
        deck = addCard(deck, 'apple', 'яблоко');
        deck = addCard(deck, 'orange', 'апельсин');

        const session = createStudySession(deck);
        const { session: updatedSession, card } = takeCard(session);
        expect(card).not.toBe(null);
        expect(updatedSession.deck.cards).toHaveLength(1);
    });

    it('should submit correct translation', () => {
        let deck = createDeck('Test Deck');
        deck = addCard(deck, 'apple', 'яблоко');

        const session = createStudySession(deck);
        const { session: updatedSession, card } = takeCard(session);
        const { session: sessionAfterSubmit, isCorrect } = submitTranslation(updatedSession, 'яблоко');

        expect(isCorrect).toBe(true);
        expect(sessionAfterSubmit.correctAttempts).toBe(1);
        expect(sessionAfterSubmit.currentCard?.isLearned).toBe(true);
    });

    it('should submit incorrect translation', () => {
        let deck = createDeck('Test Deck');
        deck = addCard(deck, 'apple', 'яблоко');

        const session = createStudySession(deck);
        const { session: updatedSession, card } = takeCard(session);
        const { session: sessionAfterSubmit, isCorrect } = submitTranslation(updatedSession, 'неправильный перевод');

        expect(isCorrect).toBe(false);
        expect(sessionAfterSubmit.incorrectAttempts).toBe(1);
        expect(sessionAfterSubmit.currentCard?.isLearned).toBe(false);
    });
});
