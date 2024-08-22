import { Card } from './Card';

export class Deck {
    deckName: string;
    creationDate: Date;
    cards: Card[] = [];
    private nextCardId: number = 1; // Для генерации уникальных id карточек

    constructor(deckName: string) {
        this.deckName = deckName;
        this.creationDate = new Date();
    }

    addCard(foreignWord: string, translation: string): void {
        const card = new Card(this.nextCardId++, foreignWord, translation);
        this.cards.push(card);
    }

    removeCard(id: number): void {
        this.cards = this.cards.filter(card => card.id !== id);
    }

    getCard(id: number): Card | null {
        return this.cards.find(card => card.id === id) || null;
    }
}