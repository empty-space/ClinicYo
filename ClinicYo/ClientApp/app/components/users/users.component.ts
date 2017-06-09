import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'users',
    templateUrl: './users.component.html'
})
export class UsersComponent {
    public users: User[];

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string,
        private route: ActivatedRoute,
        private router: Router) {
        http.get(originUrl + '/api/SampleData/Users').subscribe(result => {
            console.log(result);
            this.users = result.json() as User[];

        });
    }

}

interface User {
    id: number;
    pib: string;
    login: string;
}
