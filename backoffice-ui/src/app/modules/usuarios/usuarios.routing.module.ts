import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {AuthGuard} from "../authentication/guards/auth.guard";
import {UsuariosListarComponent} from "./pages/usuarios-listar/usuarios-listar.component";

export const routes: Routes = [
  {
    path: '',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: UsuariosListarComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class UsuariosRoutingModule {
}
