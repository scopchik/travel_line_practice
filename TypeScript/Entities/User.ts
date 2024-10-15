import { Deck } from './Deck';

export class User {
    username: string;
    password: string;
    email: string;
    decks: Deck[] = [];

    constructor(username: string, password: string, email: string) {
        this.username = username;
        this.password = password;
        this.email = email;
    }

    addDeck(deck: Deck): void {
        this.decks.push(deck);
    }

    removeDeck(deckName: string): void {
        this.decks = this.decks.filter(deck => deck.deckName !== deckName);
    }
}
