import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {AuthGuard} from "../authentication/guards/auth.guard";
import {DepartamentoListarComponent} from "./pages/departamento-listar/departamento-listar.component";

export const routes: Routes = [
  {
    path: '',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: DepartamentoListarComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class DepartamentoRoutingModule {
}
