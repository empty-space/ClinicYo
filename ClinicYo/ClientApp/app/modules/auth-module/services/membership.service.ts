import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { UserLoginVM, User, UserRegistrationVM, Locale } from '../models';


@Injectable()
export class MembershipService {
  //siteRootUrl: string = 'http://bogdankolomiec-001-site2.dtempurl.com';
  user: User = null;

  constructor(private http: Http, @Inject('ORIGIN_URL') private  siteRootUrl:string) {
    this.loadUserDataFromLocalStorage();
  }

  loadUserDataFromLocalStorage() {
      this.user = JSON.parse(localStorage.getItem('userCredentials'));
      //if (typeof window !== 'undefined') {
      //    this.user = JSON.parse(localStorage.getItem('userCredentials'));
      //}
  }

  saveUserDataToLocalStorage() {
      localStorage.setItem('userCredentials', JSON.stringify(this.user));
  }

  get isAuthorized(): boolean {
    return this.user != null && this.user.credentials.expiresIn > Date.now();
  }

  set locale(value: Locale) {
    if (this.user != null) {
      this.user.locale = value;
    }
  }

  get locale(): Locale {
    return this.user != null ? this.user.locale : Locale.Ru;
  }

  public logOut() {
    this.user = null;
    this.saveUserDataToLocalStorage();
  }

  public logIn(user: UserLoginVM): Observable<Response> {
    let options = this._getXWWWUrlEncodedHeaderOptions();
    let body = `grant_type=password&username=${user.email}&password=${user.password}`;

    return this.http.post(this.siteRootUrl + '/token', body, options)
      .map(res => {
        if (res.status === 200) {
          let data = res.json();
          this.user = {
            credentials: {
              accessTocken: data.access_token,
              expiresIn: data.expires_in,
              tokenType: data.token_type,
              userName: user.email
            },
            locale: Locale.En
          };
        } else {
          // Release
          // this.user = null;

          // Debug
          this.user = {
            credentials: {
              accessTocken: 'Q@k012jDS(1ALS-1)asdf1@1_!M1z',
              expiresIn: Date.now(),
              tokenType: "Bearer",
              userName: user.email
            },
            locale: Locale.En
          };
        }
        this.saveUserDataToLocalStorage();
        return res;
      });
  }

  public registerAdmin(user: UserRegistrationVM): Observable<Response> {
    return this._register(user, 'Admin');
  }

  public register(user: UserRegistrationVM): Observable<Response> {
    return this._register(user, 'User');
  }

  private _register(user: UserRegistrationVM, role: string): Observable<Response> {
    let options = this._getXWWWUrlEncodedHeaderOptions();

    let body = `Login=${user.email}&Password=${user.password}&PIB=${user.pib}`;

    return this.http.post(this.siteRootUrl + '/api/Auth/Register', body);//, options);
  }

  private _getXWWWUrlEncodedHeaderOptions(): RequestOptions {
    let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
    let options = new RequestOptions({ headers: headers });
    return options;
  }
}