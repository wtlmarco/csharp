import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { IMaskModule } from 'angular-imask';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { PacientesListComponent } from './components/pacientes/pacientes-list/pacientes-list.component';
import { ConveniosListComponent } from './components/convenios/convenios-list/convenios-list.component';
import { ConveniosAdicionarComponent } from './components/convenios/convenios-adicionar/convenios-adicionar.component';
import { ConveniosAtualizarComponent } from './components/convenios/convenios-atualizar/convenios-atualizar.component';
import { ConveniosRemoverComponent } from './components/convenios/convenios-remover/convenios-remover.component';
import { PacientesAdicionarComponent } from './components/pacientes/pacientes-adicionar/pacientes-adicionar.component';
import { PacientesAtualizarComponent } from './components/pacientes/pacientes-atualizar/pacientes-atualizar.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PacientesListComponent,
    ConveniosListComponent,
    ConveniosAdicionarComponent,
    ConveniosAtualizarComponent,
    ConveniosRemoverComponent,
    PacientesAdicionarComponent,
    PacientesAtualizarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    IMaskModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
