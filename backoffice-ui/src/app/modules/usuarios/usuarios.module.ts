import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsuariosListarComponent } from './pages/usuarios-listar/usuarios-listar.component';
import { UsuariosCriarComponent } from './pages/usuarios-criar/usuarios-criar.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatTabsModule} from "@angular/material/tabs";
import {MatCardModule} from "@angular/material/card";
import {MatTableModule} from "@angular/material/table";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatRadioModule} from "@angular/material/radio";
import {MatDialogModule} from "@angular/material/dialog";
import {UsuariosRoutingModule} from "./usuarios.routing.module";
 
@NgModule({
  declarations: [
    UsuariosListarComponent,
    UsuariosCriarComponent,
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
    UsuariosRoutingModule,
    ReactiveFormsModule,
    MatRadioModule,
    MatDialogModule,
  ]
})
export class UsuariosModule { }
