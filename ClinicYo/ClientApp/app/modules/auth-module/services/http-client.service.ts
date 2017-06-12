import { Injectable,Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { MembershipService } from './membership.service';

@Injectable()
export class HttpClient {

  constructor(private http: Http, private auth: MembershipService, @Inject('ORIGIN_URL') private siteRootUrl: string) { }

  createAuthorizationHeader(headers: Headers) {
    if (this.auth.user != null) {
      headers.append('AuthorizationToken', this.auth.user.credentials.accessTocken);
      headers.set('Content-type', 'application/json');
    }
  }

  get(url) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this.http.get(this.normalizeUrl(url), {
      headers: headers
    });
  }

  post(url, data) {
    let headers = new Headers();
    this.createAuthorizationHeader(headers);
    return this.http.post(this.normalizeUrl(url), data, {
      headers: headers
    });
  }

  private normalizeUrl(url: string): string {
    if (url.startsWith('https://') || url.startsWith('http://') || url.startsWith('www')) {
      return url;
    };
    if (url[0] === '/') {
      return this.siteRootUrl + url;
    } else {
      return this.siteRootUrl + '/' + url;
    }
  }
}