import { Component, Inject } from '@angular/core';
//import { Http } from '@angular/http';
import { HttpClient } from '../../modules/auth-module/services';
import { MembershipService } from '../../modules/auth-module/services';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'online-consultation-page',
    templateUrl: './online-consultation-page.component.html'
})
export class OnlineConsultationPage {
    public myConsultations: OnlineConsultation[];

    constructor(http: HttpClient, private route: ActivatedRoute, private router: Router, private auth: MembershipService) {
        http.get(`/api/online-consultation/my-consultations`).subscribe(result => {
            console.log(result);
            this.myConsultations = result.json() as OnlineConsultation[];
        });
    }
}

class OnlineConsultation {
    id: number;
    isClosed: string;
    name: string;
    messages: OnlineConsultationMessage[];
    workerId: string;
    workerName: string;    
}

class OnlineConsultationMessage {
    id: number;
    message: string;
    userId: number;
    senderName: string;
}
