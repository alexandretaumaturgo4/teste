import {Component, OnInit} from '@angular/core';
import {UsuariosService} from "../../services/usuarios.service";
import {MatDialog} from "@angular/material/dialog";
import {UsuariosCriarComponent} from "../usuarios-criar/usuarios-criar.component";
import {Usuario} from "../../models/usuario";

@Component({
  selector: 'app-usuarios-listar',
  templateUrl: './usuarios-listar.component.html',
  styleUrls: ['./usuarios-listar.component.scss']
})
export class UsuariosListarComponent implements OnInit {
  displayedColumnsUser: string[] = ['email', 'username', 'ativo', 'showDetails'];

  dataSourceUser: Usuario[] = [];

  constructor(private usuarioService: UsuariosService, private matDialog: MatDialog) {
  }

  ngOnInit(): void {
    this.carregarUsuarios();
  }

  carregarUsuarios(){
    this.usuarioService.getUsuarios().subscribe({
      next: (result: Usuario[]) => {
        this.dataSourceUser = result;
        console.log(result)
      }
    })
  }

  public desativarUsuario(idUsuario: string): void{
    this.usuarioService.desativarUsuario(idUsuario)
      .subscribe({
        next: result => {
          console.log(result)
        }
      })

    this.carregarUsuarios();

    location.reload();
  }
  openCreateUserDialog(): void {
    const dialogRef = this.matDialog.open(UsuariosCriarComponent);

    dialogRef.afterClosed().subscribe(result => {
      location.reload();
    })
  }


}
