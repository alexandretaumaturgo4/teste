import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UsuariosService} from "../../services/usuarios.service";
import {CriarUsuarioRequest} from "../../models/criar-usuario-request";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-usuarios-criar',
  templateUrl: './usuarios-criar.component.html',
  styleUrls: ['./usuarios-criar.component.scss']
})
export class UsuariosCriarComponent {
  userForm: FormGroup;

  constructor(private fb: FormBuilder, private usuariosService: UsuariosService, public dialogRef: MatDialogRef<UsuariosCriarComponent>
  ) {
    this.userForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  createUser() {
    if (this.userForm.valid) {
      const newUser: CriarUsuarioRequest = this.userForm.value;

      this.usuariosService.criarUsuario(newUser).subscribe({
        next: result => {
          this.dialogRef.close(result);

        }
      })

    }
  }
}
