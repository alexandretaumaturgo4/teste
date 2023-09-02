import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartamentoListarComponent } from './pages/departamento-listar/departamento-listar.component';
import { DepartamentoCriarComponent } from './pages/departamento-criar/departamento-criar.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatTabsModule} from "@angular/material/tabs";
import {MatCardModule} from "@angular/material/card";
import {MatTableModule} from "@angular/material/table";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatRadioModule} from "@angular/material/radio";
import {MatDialogModule} from "@angular/material/dialog";
import {DepartamentoRoutingModule} from "./departamento.routing.module";
import {MatSelectModule} from "@angular/material/select";



@NgModule({
  declarations: [
    DepartamentoListarComponent,
    DepartamentoCriarComponent
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
    DepartamentoRoutingModule,
    ReactiveFormsModule,
    MatRadioModule,
    MatDialogModule,
    MatSelectModule
  ]
})
export class DepartamentoModule { }
