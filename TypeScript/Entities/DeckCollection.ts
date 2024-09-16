import { Deck } from './Deck';

export class DeckCollection {
    private decks: Deck[] = [];

    addDeck(deck: Deck): void {
        this.decks.push(deck);
    }

    removeDeck(deckName: string): void {
        this.decks = this.decks.filter(deck => deck.deckName !== deckName);
    }

    getDeck(deckName: string): Deck | null {
        return this.decks.find(deck => deck.deckName === deckName) || null;
    }
}
