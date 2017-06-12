import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { UsersComponent } from './components/users/users.component';
import { AuthModule } from './modules/auth-module/auth.module';
import { LoginComponent } from './modules/auth-module/components/login/login.component';
import { RegistrationComponent } from './modules/auth-module/components/registration/registration.component';
import { UserDetailsComponent } from './components/users-details/users-details.component';
import { OnlineConsultationPage } from './components/online-consultation/online-consultation-page.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        UsersComponent,
        UserDetailsComponent,
        OnlineConsultationPage,
        HomeComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'users', component: UsersComponent },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegistrationComponent },
            { path: 'user/:id', component: UserDetailsComponent },
            { path: 'online-consultation/my', component: OnlineConsultationPage },
            { path: '**', redirectTo: 'home' }
        ])
        //,
        //AuthModule.forRoot()
    ]
};
