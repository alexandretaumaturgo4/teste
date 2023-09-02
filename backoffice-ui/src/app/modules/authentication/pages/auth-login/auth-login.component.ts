import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthenticationService} from "../../services/authentication.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Login} from "../../models/login";
import {finalize} from "rxjs";
import {NotificationService} from "../../../../shared/services/notification/notification.service";

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styleUrls: ['./auth-login.component.scss']
})
export class AuthLoginComponent {

  redirectTo: string;

  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private notificationService: NotificationService) {
  }

  ngOnInit(): void {
    this.redirectTo = this.activatedRoute.snapshot.queryParams['redirectTo'];
    this.createForm();
  }

  createForm(): void {
    this.loginForm = this.formBuilder.group({
      userName: [null, [Validators.required]],
      senha: [null, [Validators.required]],
    });
  }



  onSubmit(): void {
    if (this.loginForm.invalid) {
      this.notificationService.error('formulário inválido');
    }

    const login: Login = this.loginForm.value;
    login.userName = login.userName.trim();
    login.senha = login.senha.trim();

    this.authenticationService
      .login(login)
      .subscribe({
        next: (loginResponse) => {
          this.authenticationService.setTokenLocalStorage(loginResponse);
          this.authenticationService.setRoleLocalStorage(loginResponse);
          this.authenticationService.setEmailLocalStorage(loginResponse);

          location.reload();

          this.redirectTo ? this.router.navigateByUrl(this.redirectTo) : this.router.navigateByUrl('/');

          this.notificationService.success('Seja bem-vindo :)')
        },
        error: (error) => {
          this.notificationService.success('Usuário ou senha incorretos.')
        }
      })
  }
}
