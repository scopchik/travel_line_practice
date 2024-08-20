import { Card } from './Card';

export class Deck {
    deckName: string;
    creationDate: Date;
    cards: Card[] = [];

    constructor(deckName: string) {
        this.deckName = deckName;
        this.creationDate = new Date();
    }

    addCard(card: Card): void {
        this.cards.push(card);
    }

    removeCard(foreignWord: string): void {
        this.cards = this.cards.filter(card => card.foreignWord !== foreignWord);
    }
}
