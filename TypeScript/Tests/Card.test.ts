import { Card } from '../Entities/Card';

describe('Card', () => {
    let card: Card;

    beforeEach(() => {
        card = new Card('Hello', 'Привет');
    });

    it('should create a card with foreign word and translation', () => {
        expect(card.foreignWord).toBe('Hello');
        expect(card.translation).toBe('Привет');
    });

    it('should initialize isLearned to false', () => {
        expect(card.isLearned).toBe(false);
    });

    it('should mark card as learned', () => {
        card.isLearned = true;
        expect(card.isLearned).toBe(true);
    });
});
