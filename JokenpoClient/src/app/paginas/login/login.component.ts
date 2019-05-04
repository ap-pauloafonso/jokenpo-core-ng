import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/seguranca/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoginMode: boolean = true;
  Form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private router: Router, 
    private authService: AuthService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {

    this.Form = this.fb.group({
      usuario: ['', [Validators.required, Validators.maxLength(10)]],
      senha: ['', [Validators.required, Validators.maxLength(11)]]
    });


  }
  handleEntrar() { 
    this.authService.Autenticar(this.Form.controls['usuario'].value, this.Form.controls['senha'].value).subscribe(x => {
      debugger;
      this.authService.usuarioLogado = x;
      this.authService.setCookie();
      this.snackBar.open('Logado com Sucesso!', null, {
        duration: 2000,
      },);
    }, err=>{
      this.snackBar.open('Erro ao se Autenticar', null, {
        duration: 2000,
      },);
    })
  }


  handleLeftClick() {
    this.router.navigate(['registrar']);
  }

}
