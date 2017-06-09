import { Component, OnInit } from '@angular/core';
import { UserLoginVM } from '../../models';
import { MembershipService } from '../../services';

@Component({
  selector: 'app-login',
  templateUrl: 'login.component.html',
})
export class LoginComponent implements OnInit {

  user: UserLoginVM = new UserLoginVM();
  message: string = '';

  constructor(private auth: MembershipService) { }

  ngOnInit() {
  }

  login(): void {
    this.message = '';
    this.auth.logIn(this.user).subscribe(
      (res) => { this.message = res.statusText; },
      (err) => { this.message = err.json().error_description; }
    );
  }
}
