import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutBaseComponent} from "./modules/layout/components/layout-base/layout-base.component";
import {AUTH_CONFIG} from "./modules/authentication/auth.config";
import {PESSOAS_CONFIG} from "./modules/pessoas/pessoas.config";
import {USUARIOS_CONFIG} from "./modules/usuarios/usuarios.config";
import {UsuariosModule} from "./modules/usuarios/usuarios.module";
import {DEPARTAMENTOS_CONFIG} from "./modules/departamento/departamento.config";
import {DepartamentoModule} from "./modules/departamento/departamento.module";

const routes: Routes = [
  {
    path: '',
    component: LayoutBaseComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
      },
      {
        path: AUTH_CONFIG.path,
        loadChildren: () => import('./modules/authentication/authentication.module').then(m => m.AuthenticationModule)
      },
      {
        path: PESSOAS_CONFIG.path,
        loadChildren: () => import('./modules/pessoas/pessoas.module').then(m => m.PessoasModule)
      },
      {
        path: USUARIOS_CONFIG.path,
        loadChildren: () => import('./modules/usuarios/usuarios.routing.module').then(m => UsuariosModule)
      },
      {
        path: DEPARTAMENTOS_CONFIG.path,
        loadChildren: () => import('./modules/departamento/departamento.routing.module').then(m => DepartamentoModule)
      },
      {path: '', redirectTo: '/home', pathMatch: 'full'},
      {path: '**', redirectTo: '/erro', pathMatch: 'full'}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
