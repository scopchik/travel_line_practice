export type Card = {
    id: number;
    foreignWord: string;
    translation: string;
    isLearned: boolean;
};

export type Deck = {
    deckName: string;
    creationDate: Date;
    cards: Card[];
    nextCardId: number; 
};

export function createDeck(deckName: string): Deck {
    return {
        deckName,
        creationDate: new Date(),
        cards: [],
        nextCardId: 1,
    };
}

export function addCard(deck: Deck, foreignWord: string, translation: string): Deck {
    const newCard: Card = {
        id: deck.nextCardId,
        foreignWord,
        translation,
        isLearned: false
    };

    return {
        ...deck,
        cards: [...deck.cards, newCard],
        nextCardId: deck.nextCardId + 1
    };
}

export function removeCard(deck: Deck, cardId: number): Deck {
    return {
        ...deck,
        cards: deck.cards.filter(card => card.id !== cardId)
    };
}

export function getCard(deck: Deck, cardId: number): Card | null {
    return deck.cards.find(card => card.id === cardId) || null;
}