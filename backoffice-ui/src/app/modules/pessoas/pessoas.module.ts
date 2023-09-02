import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {PessoasListarComponent} from './pages/pessoas-listar/pessoas-listar.component';
import {MatButtonModule} from "@angular/material/button";
import {MatInputModule} from "@angular/material/input";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatTableModule} from "@angular/material/table";
import {MatCardModule} from "@angular/material/card";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatTabsModule} from "@angular/material/tabs";
import {PessoasRoutingModule} from "./pessoas.routing.module";
import {MatRadioModule} from "@angular/material/radio";
import {MatDialogModule} from "@angular/material/dialog";
import {PessoaFisicaCriarComponent} from "./pages/pessoa-fisica-criar/pessoa-fisica-criar.component";
import {PessoaJuridicaCriarComponent} from "./pages/pessoa-juridica-criar/pessoa-juridica-criar.component";
import {MatSelectModule} from "@angular/material/select";


@NgModule({
  declarations: [
    PessoasListarComponent,
    PessoaFisicaCriarComponent,
    PessoaJuridicaCriarComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatTabsModule,
    MatCardModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    PessoasRoutingModule,
    ReactiveFormsModule,
    MatRadioModule,
    MatDialogModule,
    MatSelectModule
  ],
  providers: []
})

export class PessoasModule {
}
