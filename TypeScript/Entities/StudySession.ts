import { Deck, Card } from './Deck';

export type StudySession = {
    deck: Deck;
    currentCard: Card | null;
    correctAttempts: number;
    incorrectAttempts: number;
};

export function createStudySession(deck: Deck): StudySession {
    return {
        deck: { ...deck, cards: shuffle(deck.cards) }, // Перемешиваем карты в начале сессии
        currentCard: null,
        correctAttempts: 0,
        incorrectAttempts: 0,
    };
}

export function takeCard(session: StudySession): { session: StudySession; card: Card | null } {
    const [nextCard, ...remainingCards] = session.deck.cards;

    return {
        session: {
            ...session,
            deck: { ...session.deck, cards: remainingCards },
            currentCard: nextCard || null,
        },
        card: nextCard || null,
    };
}

export function submitTranslation(session: StudySession, translation: string): { session: StudySession; isCorrect: boolean } {
    if (!session.currentCard) {
        return { session, isCorrect: false };
    }

    const isCorrect = translation === session.currentCard.translation;

    const updatedSession = {
        ...session,
        correctAttempts: session.correctAttempts + (isCorrect ? 1 : 0),
        incorrectAttempts: session.incorrectAttempts + (!isCorrect ? 1 : 0),
        currentCard: {
            ...session.currentCard,
            isLearned: isCorrect ? true : session.currentCard.isLearned, // Обновляем статус "изучено"
        },
    };

    return { session: updatedSession, isCorrect };
}

export function shuffle(array: Card[]): Card[] {
    const shuffledArray = [...array];
    for (let i = shuffledArray.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [shuffledArray[i], shuffledArray[j]] = [shuffledArray[j], shuffledArray[i]];
    }
    return shuffledArray;
}