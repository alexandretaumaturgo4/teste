import {Component} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {DepartamentoCriarComponent} from "../departamento-criar/departamento-criar.component";
import {DepartamentoService} from "../../services/departamento.service";
import {Departamento} from "../../models/departamento";

@Component({
  selector: 'app-departamento-listar',
  templateUrl: './departamento-listar.component.html',
  styleUrls: ['./departamento-listar.component.scss']
})
export class DepartamentoListarComponent {
  displayedColumnsDepartamento: string[] = ['nomeDepartamento', 'nomeResponsavel'];
  dataSourceDepartamento : Departamento[] = [
  ];

  constructor(public dialog: MatDialog, private departamentoService: DepartamentoService) {
  }

  ngOnInit(): void {
    this.departamentoService.getDepartamentos().subscribe({
      next: response => {
        this.dataSourceDepartamento =  response;
      }
    })
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DepartamentoCriarComponent);

    dialogRef.afterClosed().subscribe(result => {
      location.reload();
    });
  }

  showDetails(element: any): void {
    // Implemente a lógica para mostrar detalhes do departamento aqui
  }
}
