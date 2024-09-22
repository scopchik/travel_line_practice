
export type Card = {
    id: number;
    foreignWord: string;
    translation: string;
    isLearned: boolean;
};

export function createCard(id: number, foreignWord: string, translation: string): Card {
    return {
        id,
        foreignWord,
        translation,
        isLearned: false
    };
}
export function markCardAsLearned(card: Card): Card {
    return { ...card, isLearned: true };
}