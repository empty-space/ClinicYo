import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router';
import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'user-details',
    templateUrl: './users-details.component.html'
})


export class UserDetailsComponent implements OnInit {
    public user: UserDetailsVm;
    public allowEdit: boolean = false;

    constructor(private http: Http, @Inject('ORIGIN_URL') private originUrl: string,
        private route: ActivatedRoute,
        private router: Router) {
        // this.route.params
        //     .map(params => params['id'])
        //     .subscribe((id) => this.getUser(+id));
    }
    ngOnInit() {
        // subscribe to router event
        this.route.params.subscribe((params: Params) => {
            let userId = params['id'];
            this.getUser(userId);
        });
    }

    getUser(id: number) {
        this.http.get(this.originUrl + '/api/SampleData/users/' + id).subscribe(result => {
            this.user = result.json() as UserDetailsVm;
        });
    }
}

export class UserDetailsVm {
    id: number;
    pib: string;
    login: string;
    menus: MenuVm[];
    rights: AccessRightVm[];
}

interface MenuVm {
    id: number;
    name: string;
    allowed: boolean;
}



interface AccessRightVm {
    id: number;
    name: string;
    allowed: boolean;
}