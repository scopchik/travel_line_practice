import { createCard, markCardAsLearned, Card } from '../Entities/Card';

describe('Card', () => {
    it('should create a new card with correct properties', () => {
        const card: Card = createCard(1, 'hello', 'привет');

        expect(card.id).toBe(1);
        expect(card.foreignWord).toBe('hello');
        expect(card.translation).toBe('привет');
        expect(card.isLearned).toBe(false);
    });

    it('should mark a card as learned', () => {
        let card: Card = createCard(2, 'orange', 'апельсин');
        expect(card.isLearned).toBe(false);

        card = markCardAsLearned(card);

        expect(card.isLearned).toBe(true);
    });
});
