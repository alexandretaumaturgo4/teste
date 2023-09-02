import {Component} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {MatDialog} from "@angular/material/dialog";
import {PessoasService} from "../../services/pessoas.service";
import {PessoaFisica, PessoaJuridica} from "../../models/pessoa-fisica.model";
import {PessoaFisicaCriarComponent} from "../pessoa-fisica-criar/pessoa-fisica-criar.component";
import {PessoaJuridicaCriarComponent} from "../pessoa-juridica-criar/pessoa-juridica-criar.component";
import {AuthenticationService} from "../../../authentication/services/authentication.service";


@Component({
  selector: 'app-pessoas-listar',
  templateUrl: './pessoas-listar.component.html',
  styleUrls: ['./pessoas-listar.component.scss']
})
export class PessoasListarComponent {

  userRole: string;

  displayedColumnsPessoaFisica: string[] = ['nome', 'documento'];
  displayedColumnsPessoaJuridica: string[] = ['razaoSocial', 'documento'];

  dataSourcePessoaFisica: PessoaFisica[] = [];

  dataSourcePessoaJuridica: PessoaJuridica[] = [];

  constructor(public dialog: MatDialog, private pessoaService: PessoasService, private authenticationService: AuthenticationService) {

  }

  ngOnInit(): void {
    this.userRole = this.authenticationService.getUserRole().toString();

    this.montarGrids();
  }

  montarGrids() {
    if (this.userRole === 'administrador') {
      this.pessoaService.getPessoasFisicas().subscribe({
        next: result => {
          this.dataSourcePessoaFisica = result;
        }
      })

      this.pessoaService.getPessoasJuridicas().subscribe({
        next: result => {
          this.dataSourcePessoaJuridica = result;
        }
      })
    }
  }

  openDialog(tipo: string): void {

    let dialogToOpen;

    if (tipo === 'fisica') {
      dialogToOpen = PessoaFisicaCriarComponent;
    } else {
      dialogToOpen = PessoaJuridicaCriarComponent;
    }

    const dialogRef = this.dialog.open(dialogToOpen);
    dialogRef.afterClosed().subscribe(result => {
      location.reload();
    });
  }

  showDetails(element: any): void {
    // Aqui você pode implementar a lógica para mostrar mais detalhes sobre a pessoa
    console.log('Mostrar detalhes para: ', element);
  }

}
