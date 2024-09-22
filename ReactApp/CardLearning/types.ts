export interface Card {
    id: number;
    word: string;
    translation: string;
}
  
export interface Deck {
    id: number;
    name: string;
    cards: Card[];
}