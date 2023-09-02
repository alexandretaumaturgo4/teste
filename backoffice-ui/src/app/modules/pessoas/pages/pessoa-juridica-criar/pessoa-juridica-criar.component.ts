import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {PessoasService} from "../../services/pessoas.service";
import {MatDialogRef} from "@angular/material/dialog";
import {PessoaFisicaModelRequest, PessoaJuridicaModelRequest} from "../../models/pessoa-fisica.model";
import {NotificationService} from "../../../../shared/services/notification/notification.service";
import {ViaCepService} from "../../../../shared/utils/via-cep.service";

@Component({
  selector: 'app-pessoa-juridica-criar',
  templateUrl: './pessoa-juridica-criar.component.html',
  styleUrls: ['./pessoa-juridica-criar.component.scss']
})
export class PessoaJuridicaCriarComponent {
  form: FormGroup;

  constructor(private fb: FormBuilder
    , private pessoaService: PessoasService
    , public dialogRef: MatDialogRef<PessoaJuridicaCriarComponent>
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
      RazaoSocial: ['', Validators.required],
      NomeFantasia: [''],
      Cnpj: ['', Validators.required],
      Qualificacao: ['', Validators.required],
      Cep: ['', Validators.required],
      Rua: ['', Validators.required],
      Numero: ['', Validators.required],
      Bairro: ['', Validators.required],
      Cidade: ['', Validators.required],
      Estado: ['', Validators.required],
    });
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

    let modelRequest: PessoaJuridicaModelRequest = this.form.value;

    if (this.form.valid) {
      this.pessoaService.salvarPessoaJuridica(modelRequest)
        .subscribe({
          next: result => {
            this.dialogRef.close();
          }
        })
    } else {
      this.notificationService.error('Formulário inválido');
    }
  }
}
