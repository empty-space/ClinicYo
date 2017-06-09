import { UserCredentials } from './user-credentials';
import { Locale } from './locales';

export class User {
    public credentials: UserCredentials;

    public locale: Locale;

    constructor(credentials: UserCredentials, locale: Locale) {
        this.credentials = credentials;
        this.locale = locale;
    }
}