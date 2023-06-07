import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public invalidLogin: boolean = false;

  constructor(private router: Router, private http: HttpClient, private notification: NotificationService) { }

  ngOnInit(): void {
  }

  public login = (form: NgForm) => {
    const credentials = JSON.stringify(form.value);

    this.http.post(environment.baseUrl + "authenticate/login",
      credentials
    ).subscribe({
      next: (response) => {
        this.notification.showSuccess("User login successful", "Success")
        const token = (<any>response).token;
        const refreshToken = (<any>response).refreshToken;
        localStorage.setItem("accessToken", token);
        localStorage.setItem("refreshToken", refreshToken);
        this.invalidLogin = false;
        this.router.navigate(["/"]);
      },
      error: (err) => {
        this.notification.showError("Invalid username or password.", "Error")
        console.error(err)
        this.invalidLogin = true;
      },
      complete: () => console.info('Login complete')
    });
  }
}
