import { Card } from '../Entities/Card';

describe('Card', () => {
    it('should create a card with id, foreignWord, and translation', () => {
        const card = new Card(1, 'Cat', 'Кот');
        expect(card.id).toBe(1);
        expect(card.foreignWord).toBe('Cat');
        expect(card.translation).toBe('Кот');
        expect(card.isLearned).toBe(false);
    });

    it('should be able to mark card as learned', () => {
        const card = new Card(1, 'Cat', 'Кот');
        card.isLearned = true;
        expect(card.isLearned).toBe(true);
    });
});
