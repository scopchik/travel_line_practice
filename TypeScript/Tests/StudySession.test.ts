import { StudySession } from '../Entities/StudySession';
import { Deck } from '../Entities/Deck';
import { Card } from '../Entities/Card';

describe('StudySession', () => {
    let deck: Deck;
    let session: StudySession;
    let card1: Card;
    let card2: Card;

    beforeEach(() => {
        deck = new Deck('Test Deck');
        card1 = new Card('Hello', 'Привет');
        card2 = new Card('Goodbye', 'До свидания');
        deck.addCard(card1);
        deck.addCard(card2);
        session = new StudySession(deck);
    });

    it('should start the session and shuffle cards', () => {
        session.startSession();
        expect(deck.cards.length).toBe(2); // Убедитесь, что метод shuffle() не изменяет количество карт
    });

    it('should take a card', () => {
        session.startSession();
        const card = session.takeCard();
        expect(card).not.toBeNull();
        expect(deck.cards.length).toBe(1); // Предположим, что одна карта должна быть взята
    });

    it('should submit correct translation', () => {
        session.startSession();
        const card = session.takeCard();
        const result = session.submitTranslation('Привет');
        expect(result).toBe(true);
        expect(session.correctAttempts).toBe(1);
        expect(session.incorrectAttempts).toBe(0);
    });

    it('should submit incorrect translation', () => {
        session.startSession();
        session.takeCard();
        const result = session.submitTranslation('Неправильно');
        expect(result).toBe(false);
        expect(session.correctAttempts).toBe(0);
        expect(session.incorrectAttempts).toBe(1);
    });
});
