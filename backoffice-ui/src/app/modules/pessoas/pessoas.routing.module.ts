import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {PessoasListarComponent} from "./pages/pessoas-listar/pessoas-listar.component";
import {PessoaFisicaCriarComponent} from "./pages/pessoa-fisica-criar/pessoa-fisica-criar.component";
import {PessoaJuridicaCriarComponent} from "./pages/pessoa-juridica-criar/pessoa-juridica-criar.component";
import {AuthGuard} from "../authentication/guards/auth.guard";

export const routes: Routes = [
  {
    path: '',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    component: PessoasListarComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class PessoasRoutingModule {
}
