import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { PacientesListComponent } from './components/pacientes/pacientes-list/pacientes-list.component';
import { PacientesAdicionarComponent } from './components/pacientes/pacientes-adicionar/pacientes-adicionar.component';
import { PacientesAtualizarComponent } from './components/pacientes/pacientes-atualizar/pacientes-atualizar.component';
import { ConveniosListComponent } from './components/convenios/convenios-list/convenios-list.component';
import { ConveniosAdicionarComponent } from './components/convenios/convenios-adicionar/convenios-adicionar.component';
import { ConveniosAtualizarComponent } from './components/convenios/convenios-atualizar/convenios-atualizar.component';
import { ConveniosRemoverComponent } from './components/convenios/convenios-remover/convenios-remover.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'pacientes',
    component: PacientesListComponent
  },
  {
    path: 'pacientes/adicionar',
    component: PacientesAdicionarComponent
  },
  {
    path: 'pacientes/atualizar/:id',
    component: PacientesAtualizarComponent
  },
  {
    path: 'convenios',
    component: ConveniosListComponent
  },
  {
    path: 'convenios/adicionar',
    component: ConveniosAdicionarComponent
  },
  {
    path: 'convenios/atualizar/:id',
    component: ConveniosAtualizarComponent
  },
  {
    path: 'convenios/remover/:id',
    component: ConveniosRemoverComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
