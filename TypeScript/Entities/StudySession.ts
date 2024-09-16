import { Deck } from './Deck';
import { Card } from './Card';

export class StudySession {
    deck: Deck;
    currentCard: Card | null = null;
    correctAttempts: number = 0;
    incorrectAttempts: number = 0;

    constructor(deck: Deck) {
        this.deck = deck;
    }

    startSession(): void {
        this.deck.cards = this.shuffle(this.deck.cards);
    }

    takeCard(): Card | null {
        if (this.deck.cards.length > 0) {
            this.currentCard = this.deck.cards.shift()!;
            return this.currentCard;
        }
        return null;
    }

    submitTranslation(translation: string): boolean {
        if (this.currentCard) {
            if (translation === this.currentCard.translation) {
                this.correctAttempts++;
                this.currentCard.isLearned = true;
                return true;
            } else {
                this.incorrectAttempts++;
                return false;
            }
        }
        return false;
    }

    private shuffle(array: Card[]): Card[] {
        for (let i = array.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [array[i], array[j]] = [array[j], array[i]];
        }
        return array;
    }
}
