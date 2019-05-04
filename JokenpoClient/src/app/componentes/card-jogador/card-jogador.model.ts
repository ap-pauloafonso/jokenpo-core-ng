export class CardJogadorModel {

    /**
     *
     */
    constructor(isBoot: boolean, state: string, user: string = '') {

        this.isBoot = isBoot;
        this.state = state;
        this.user = user;
    }
    isBoot: boolean;
    state: string;
    user: string;
}