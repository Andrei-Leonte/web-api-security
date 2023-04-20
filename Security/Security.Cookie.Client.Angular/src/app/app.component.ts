import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  template: `<h2>I'm dynamically attached</h2>`
})

export class AppComponent {
  url = "https://localhost:2110"
  username = "leonteiandrei@gmail.com";
  password = "Andrei12345.#";
  imagePath = "";
  containers = [];

  title = 'Security.Cookie.Client.Angular';

  constructor(private http: HttpClient) {
  }

  login() {
    const url = this.url +'/api/Account/signin';
    const data = { email: this.username, password: this.password, rememberMe: true };

    this.http.post(url, data, { withCredentials: true }).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
    });
  }

  testSecureAPIOverHttps() {
    var url1 = this.url + '/api/Authorized/test1';

    this.http.get(url1, { withCredentials: true }).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
    });
  }

  configureCSP() {
    var url1 = this.url + '/api/csp/add';

    this.http.get(url1, { withCredentials: true, observe: 'response' }).subscribe(response => {
      const cspValue = response.headers.get('csp');

      console.log(response)
      this.addCSPMetaTag(cspValue!!)
      console.log(response);
    }, error => {
      console.error(error);
    });
  }

  testCSP() {
    this.containers.push();
    this.containers.push();
    const SCRIPT_PATH = 'https://apis.google.com/js/api.js';

    const script = document.createElement('script');
    script.src = 'https://apis.google.com/js/api.js';
    document.body.appendChild(script);
  }

  testRateLimiting() {
    var url1 = this.url + '/api/public/usv';

    for (var i = 0; i < 30; i++) {
      this.http.get(url1, { withCredentials: true }).subscribe(response => {
        console.log(response);
      }, error => {
        console.error(error);
      });
    }
  }

  addCSPMetaTag(cspValue: string) {
    console.log("cspValue ===> ", cspValue)
    const meta = document.createElement('meta');
    meta.setAttribute('http-equiv', 'Content-Security-Policy');
    meta.setAttribute('content', cspValue);
    document.getElementsByTagName('head')[0].appendChild(meta);
  }
}
