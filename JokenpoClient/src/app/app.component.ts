import { Component } from '@angular/core';
import { AuthService } from './shared/seguranca/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  /**
   *
   */
  constructor(public authService: AuthService) {
  }
  title = 'JokenpoClient';


  handleSair(){
    this.authService.logout()
  }
}

