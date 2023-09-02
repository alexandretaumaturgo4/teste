import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {DepartamentoService} from "../../services/departamento.service";
import {Colaborador, CriarDepartamentoRequest} from "../../models/colaborador";
import {NotificationService} from "../../../../shared/services/notification/notification.service";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-departamento-criar',
  templateUrl: './departamento-criar.component.html',
  styleUrls: ['./departamento-criar.component.scss']
})
export class DepartamentoCriarComponent {
  departamentoForm: FormGroup;
  colaboradores: Colaborador[] = [];

  constructor(
    private fb: FormBuilder,
    private departamentoService: DepartamentoService,
    private notificationService: NotificationService,
    public dialogRef: MatDialogRef<DepartamentoCriarComponent>
  ) {
    this.departamentoForm = this.fb.group({
      nome: ['', Validators.required],
      documentoResponsavel: ['', Validators.required]
    });
  }

  ngOnInit(): void {

    this.departamentoService.getColaboradores()
      .subscribe(data => {
        this.colaboradores = data;
        console.log(this.colaboradores)
      });
  }

  cadastrarDepartamento() {
    if (this.departamentoForm.valid) {
      const novoDepartamento: CriarDepartamentoRequest = this.departamentoForm.value;

      this.departamentoService.criarDepartamento(novoDepartamento).subscribe({
        next: (result) => {
          this.dialogRef.close();
        }, error: err => {
          this.notificationService.error(err.error.mensagem)
        }
      });
    }
  }
}
