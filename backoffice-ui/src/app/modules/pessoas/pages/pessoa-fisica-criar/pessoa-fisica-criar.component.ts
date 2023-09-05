import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {PessoasService} from "../../services/pessoas.service";
import {PessoaFisicaModelRequest} from "../../models/pessoa-fisica.model";
import {MatDialogRef} from "@angular/material/dialog";
import {NotificationService} from "../../../../shared/services/notification/notification.service";
import {ViaCepService} from "../../../../shared/utils/via-cep.service";

@Component({
  selector: 'app-pessoa-fisica-criar',
  templateUrl: './pessoa-fisica-criar.component.html',
  styleUrls: ['./pessoa-fisica-criar.component.scss']
})
export class PessoaFisicaCriarComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder
    , private pessoaService: PessoasService
    , public dialogRef: MatDialogRef<PessoaFisicaCriarComponent>
    , private notificationService: NotificationService
    , private viaCepService: ViaCepService) {
  }

  qualificacoes = [
    {
      tipo: 'Cliente',
      valor: 1
    },
    {
      tipo: 'Fornecedor',
      valor: 2
    },
    {
      tipo: 'Colaborador',
      valor: 3
    }];


  ngOnInit(): void {
    this.form = this.fb.group({
      Nome: ['', Validators.required],
      Apelido: [''],
      Cpf: ['', Validators.required],
      Qualificacao: ['', Validators.required],
      Cep: ['', Validators.required],
      Rua: ['', Validators.required],
      Numero: ['', Validators.required],
      Bairro: ['', Validators.required],
      Cidade: ['', Validators.required],
      Estado: ['', Validators.required],
    });

    this.buscarPorCep();
  }


  buscarPorCep() {
    const cep = this.form.get('Cep').value;
    if (cep && cep.length === 8) {

      this.viaCepService.getByCep(cep).subscribe({
        next: endereco => {
          this.form.patchValue({
            Rua: endereco.logradouro,
            Bairro: endereco.bairro,
            Cidade: endereco.localidade,
            Estado: endereco.uf
          });
        }
      })
    }
  }

  onSubmit(): void {

    let newPessoaFisica: PessoaFisicaModelRequest = this.form.value;

    if (this.form.valid) {
      this.pessoaService.salvarPessoaFisica(newPessoaFisica)
        .subscribe({
          next: result => {
            this.dialogRef.close();
          }, error: err => {
            console.log(err)
            this.notificationService.error(err.error.mensagem);
          }
        })
    } else {
      this.notificationService.error('Formulário inválido');
    }
  }
}
