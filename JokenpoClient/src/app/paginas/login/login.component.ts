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

    if (this.authService.estaLogado) {
      this.router.navigate(['/home'])
    }

    this.Form = this.fb.group({
      usuario: ['', [Validators.required, Validators.maxLength(25)]],
      senha: ['', [Validators.required, Validators.maxLength(50)]]
    });




  }
  handleEntrar() {
    this.authService.Autenticar(this.Form.controls['usuario'].value, this.Form.controls['senha'].value).subscribe(x => {
      this.snackBar.open('Logado com Sucesso!', null, {
        duration: 2000,
      });
      this.router.navigate(['/home']);
    }, err => {
      this.snackBar.open(err, null, {
        duration: 2000,
      });
    })
  }


  handleLeftClick() {
    this.router.navigate(['registrar']);
  }

}
