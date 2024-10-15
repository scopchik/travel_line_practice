import { Deck } from './Deck';

export type DeckCollection = {
    decks: Deck[];
};

export function createDeckCollection(): DeckCollection {
    return {
        decks: []
    };
}

export function addDeck(collection: DeckCollection, deck: Deck): DeckCollection {
    return {
        ...collection,
        decks: [...collection.decks, deck]
    };
}

export function removeDeck(collection: DeckCollection, deckName: string): DeckCollection {
    return {
        ...collection,
        decks: collection.decks.filter(deck => deck.deckName !== deckName)
    };
}

export function getDeck(collection: DeckCollection, deckName: string): Deck | null {
    return collection.decks.find(deck => deck.deckName === deckName) || null;
}