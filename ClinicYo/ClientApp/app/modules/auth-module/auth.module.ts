import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MembershipService, HttpClient } from './services';
import { LoginComponent, RegistrationAdminComponent, RegistrationComponent, UserBoxComponentComponent } from './components';

@NgModule({
    imports: [
        CommonModule, FormsModule, HttpModule, RouterModule
  ],
  declarations: [
    LoginComponent, RegistrationComponent,
    RegistrationAdminComponent, UserBoxComponentComponent
  ],
  exports: [LoginComponent, RegistrationComponent, RegistrationAdminComponent, UserBoxComponentComponent]
})
export class AuthModule {
    static forRoot() {
        return { ngModule: AuthModule, providers: [MembershipService, HttpClient] };
  };

}
