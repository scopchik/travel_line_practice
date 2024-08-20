export class Card {
    foreignWord: string;
    translation: string;
    isLearned: boolean = false;

    constructor(foreignWord: string, translation: string) {
        this.foreignWord = foreignWord;
        this.translation = translation;
    }
}
