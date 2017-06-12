import { Component, Inject } from '@angular/core';
//import { Http } from '@angular/http';
import { HttpClient } from '../../modules/auth-module/services';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'users',
    templateUrl: './users.component.html'
})
export class UsersComponent {
    public users: User[];

    constructor(http: HttpClient, @Inject('ORIGIN_URL') originUrl: string,
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
