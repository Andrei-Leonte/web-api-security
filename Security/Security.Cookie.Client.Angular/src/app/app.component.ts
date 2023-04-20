import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  template: `<h2>I'm dynamically attached</h2>`
})

export class AppComponent {
  username = "";
  password = "";
  imagePath = ""
  containers = [];

  title = 'Security.Cookie.Client.Angular';

  constructor(private http: HttpClient) {
  }

  login() {
    const url = 'https://localhost:2110/api/Account/signin';
    const data = { email: 'leonteiandrei@gmail.com', password: 'Andrei12345.#', rememberMe: true };

    this.http.post(url, data, { withCredentials: true }).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
    });
  }

  testSecureAPIOverHttps() {
    var url1 = 'https://localhost:2110/api/test/test1';
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': 'https://localhost:2110',
        'Access-Control-Allow-Credentials': 'true'
      }),
      withCredentials: true
    };

    this.http.get(url1, { withCredentials: true }).subscribe(response => {
      console.log(response);
    }, error => {
      console.error(error);
    });
  }

  testCSP() {
    this.containers.push();
    this.containers.push();
    const SCRIPT_PATH = 'https://apis.google.com/js/api.js';
  }
}
