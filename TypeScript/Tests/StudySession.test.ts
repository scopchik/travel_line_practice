import { StudySession } from '../Entities/StudySession';
import { Deck } from '../Entities/Deck';
import { Card } from '../Entities/Card';

describe('StudySession', () => {
    let deck: Deck;
    let studySession: StudySession;

    beforeEach(() => {
        deck = new Deck('Test Deck');
        deck.addCard('Hello', 'Привет');
        deck.addCard('Cat', 'Кот');
        studySession = new StudySession(deck);
    });

    it('should start a study session', () => {
        studySession.startSession();
        expect(studySession.deck.cards.length).toBe(2);
    });

    it('should take a card from the deck', () => {
        studySession.startSession();
        const card = studySession.takeCard();
        expect(card).toBeDefined();
        expect(studySession.currentCard).toBe(card);
    });

    it('should submit correct translation', () => {
        studySession.startSession();
        studySession.takeCard();
        const result = studySession.submitTranslation('Привет');
        expect(result).toBe(true);
        expect(studySession.correctAttempts).toBe(1);
    });

    it('should submit incorrect translation', () => {
        studySession.startSession();
        studySession.takeCard();
        const result = studySession.submitTranslation('Неверный перевод');
        expect(result).toBe(false);
        expect(studySession.incorrectAttempts).toBe(1);
    });

    it('should return null when taking a card if deck is empty', () => {
        studySession.startSession();
        studySession.takeCard();
        studySession.takeCard();
        const card = studySession.takeCard();
        expect(card).toBeNull();
    });
});