import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { authCodeFlowConfig } from './Consts/OAuth2Const';
import { UserData } from './Interfaces/OAuth2Interfaces';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public isButtonDisabled = false;
  public showUserName = false;
  public userName: any
  public identityResponse: any
  public user: any
  public authorizeHeaders: HttpHeaders = new HttpHeaders;
  
  constructor(private oauthService: OAuthService, private activatedRoute: ActivatedRoute, private http: HttpClient) {
  }

  ngOnInit() {
    this.oauthService.configure(authCodeFlowConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();

    if (this.oauthService.hasValidIdToken()) {
      this.isButtonDisabled = true
      this.authorizeHeaders = new HttpHeaders({
        'Authorization': 'Bearer ' + window.sessionStorage.getItem('id_token')
        }) 
    }
  }

  signin() {
    this.oauthService.initLoginFlow();
  }

  signout() {
  }
  getUserName() {
    this.oauthService.loadUserProfile()
      .then(data => {
        const userData = data as UserData;
        this.userName = userData.info.name;
        this.showUserName = true;
      })
      .catch(error => console.log("Error loading the users: ", error));
  }

  checkIdentity() {
    this.http.get('https://localhost:2103/identity/get', { headers: this.authorizeHeaders }).subscribe((data) => {
      this.identityResponse = JSON.stringify(data);
    }, (error) => {
      console.error(error);
    });
  }
}
