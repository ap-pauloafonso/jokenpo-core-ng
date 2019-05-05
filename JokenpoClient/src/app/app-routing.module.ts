import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './paginas/login/login.component';
import { JogarComponent } from './paginas/jogar/jogar.component';
import { RegisterComponent } from './paginas/register/register.component';
import { AuthGuard } from './shared/seguranca/auth.guard';
import { HomeComponent } from './paginas/home/home.component';

const routes: Routes = [
  { 
    path: '*',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  { 
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'registrar',
    component: RegisterComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'jogar',
    canActivate:[AuthGuard],
    component: JogarComponent
  },
  {
    path: 'home',
    canActivate:[AuthGuard],
    component: HomeComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
