import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/seguranca/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  Form: FormGroup;
  constructor(private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {

    this.Form = this.fb.group({
      usuario: ['', [Validators.required, Validators.maxLength(25)]],
      senha: ['', [Validators.required, Validators.maxLength(50)]],
      senhaConfirma: ['', [Validators.required]],
      email: ['', [Validators.email, Validators.maxLength(30)]]
    });


  }

  handleRegistrar() {
    if (this.Form.valid) {
      this.authService.Cadastrar(this.Form.controls['usuario'].value, this.Form.controls['senha'].value, this.Form.controls['email'].value)
        .subscribe(x => {
          this.authService.usuarioLogado = x;
          this.authService.setCookie();
          this.snackBar.open('Logado com Sucesso!', null, {
            duration: 2000,
          });
        }, err => {
          this.snackBar.open('Ocorreu algum problema no cadastro!', null, {
            duration: 2000,
          });
        })
    }
  }
  handleCancelar() {

  }

}
