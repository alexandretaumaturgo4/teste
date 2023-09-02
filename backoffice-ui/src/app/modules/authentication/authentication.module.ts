import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AuthLoginComponent} from './pages/auth-login/auth-login.component';
import {ReactiveFormsModule} from "@angular/forms";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {MatInputModule} from "@angular/material/input";
import {AuthenticationRoutingModule} from "./authentication.routing.module";
import {AuthenticationService} from "./services/authentication.service";
import {StorageService} from "../../shared/services/via-cep/via-cep.service";
import {NotificationService} from "../../shared/services/notification/notification.service";


@NgModule({
  declarations: [
    AuthLoginComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    AuthenticationRoutingModule,
  ],
  providers: [
    AuthenticationService,
    StorageService,
    NotificationService
  ]
})
export class AuthenticationModule {
}
