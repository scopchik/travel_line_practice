export class Card {
    id: number;
    foreignWord: string;
    translation: string;
    isLearned: boolean = false;

    constructor(id: number, foreignWord: string, translation: string) {
        this.id = id;
        this.foreignWord = foreignWord;
        this.translation = translation;
    }
}