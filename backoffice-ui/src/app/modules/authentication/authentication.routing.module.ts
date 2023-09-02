import {NgModule} from "@angular/core";
import {RouterModule, Routes} from "@angular/router";
import {AuthLoginComponent} from "./pages/auth-login/auth-login.component";
import {LoginGuard} from "./guards/login.guard";

export const routes: Routes = [
  {
    path: 'login',
    canActivate: [LoginGuard],
    component: AuthLoginComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class AuthenticationRoutingModule {}
