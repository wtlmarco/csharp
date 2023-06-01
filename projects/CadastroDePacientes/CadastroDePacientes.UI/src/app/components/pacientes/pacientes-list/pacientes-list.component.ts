import { Component, OnInit } from '@angular/core';
import * as IMask from 'imask';

import { Paciente } from 'src/app/models/paciente.model';
import { PacientesService } from 'src/app/services/pacientes.service';

@Component({
  selector: 'app-paciente-list',
  templateUrl: './pacientes-list.component.html',
  styleUrls: ['./pacientes-list.component.css']
})

export class PacientesListComponent implements OnInit{
  
  pacientes: Paciente[] = [];

  constructor(private pacientesService: PacientesService) {}

  phoneMask = { mask: "(00) 0000-0000" };
  celphoneMask = { mask: "(00) 00000-0000" };
  cpfMask = { mask: "000.000.000-00" };
  dateMask = { mask: "dd/mm/yyyy" };

  ngOnInit(): void {
    this.pacientesService.listar()
      .subscribe({
        next: (resposta) => {
          this.pacientes = resposta;
        },
        error: (resposta) => {
          console.log(resposta)
        }
      });
  }
}
