export class CardJogadorModel {

    /**
     *
     */
    constructor(isBoot: boolean, state: string, user: string, email: string) {

        this.isBoot = isBoot;
        this.state = state;
        this.user = user;
        this.email = email;
    }
    isBoot: boolean;
    state: string;
    user: string;
    email: string;
}