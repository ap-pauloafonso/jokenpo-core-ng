import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar'
import { FlexLayoutModule } from "@angular/flex-layout";
import { JogarComponent } from './paginas/jogar/jogar.component';
import { CardJogadorComponent } from './componentes/card-jogador/card-jogador.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { PlacarComponent } from './componentes/placar/placar.component';
import { FinalPartidaComponent } from './componentes/final-partida/final-partida.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table';
import { LoginComponent } from './paginas/login/login.component';
import {MatInputModule} from '@angular/material/input';
import { RegisterComponent } from './paginas/register/register.component'
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { HomeComponent } from './paginas/home/home.component';
import {MatMenuModule} from '@angular/material/menu';

// import { CorpoCardComponent } from './shared/componentes/corpo-card/corpo-card.component';


// import { FontAwesomeModule } from '@fortawesome/fontawesome-free';

@NgModule({
  declarations: [
    AppComponent,
    JogarComponent,
    CardJogadorComponent,
    PlacarComponent,
    FinalPartidaComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatChipsModule,
    MatCardModule,
    MatToolbarModule,
    FlexLayoutModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatTableModule,
    MatInputModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSnackBarModule,
    MatMenuModule

  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[FinalPartidaComponent]
})
export class AppModule { }
