import { Component, OnInit } from '@angular/core';

import { MembershipService } from '../../services';

@Component({
  selector: 'app-user-box-component',
  templateUrl: 'user-box-component.component.html',
})
export class UserBoxComponentComponent implements OnInit {
  constructor(private auth: MembershipService) { }

  ngOnInit() {
  }

  logIn() {
    // const modalRef = this.modalService.open(LoginComponent);
    // modalRef.componentInstance.name = 'Login';
  }
  registration() {
    // const modalRef = this.modalService.open(RegistrationComponent, { windowClass: '' });
    // modalRef.componentInstance.name = 'Registration';
  }

  logOut() {
    this.auth.logOut();
  }

}
