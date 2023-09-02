import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {PageErroComponent} from "./page-erro/page-erro.component";
import {PageHomeComponent} from "./page-home/page-home.component";
import {AuthGuard} from "../authentication/guards/auth.guard";

export const routes: Routes = [
  {
    path: 'home',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: PageHomeComponent
  },
  {
    path: 'erro',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: PageErroComponent
  },
  {path: '', redirectTo: 'home', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class HomeRoutingModule {
}
