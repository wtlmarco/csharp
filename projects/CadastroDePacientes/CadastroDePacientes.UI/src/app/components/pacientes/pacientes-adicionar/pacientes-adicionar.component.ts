import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Paciente } from 'src/app/models/paciente.model';
import { Convenio } from 'src/app/models/convenio.model';
import { PacientesService } from 'src/app/services/pacientes.service';
import { ConveniosService } from 'src/app/services/convenios.service';

@Component({
  selector: 'app-pacientes-adicionar',
  templateUrl: './pacientes-adicionar.component.html',
  styleUrls: ['./pacientes-adicionar.component.css']
})

export class PacientesAdicionarComponent implements OnInit{
  mensagens: string[] = [];

  paciente: Paciente = {
    id: '',
    nome: '',
    sobrenome: '',
    dataDeNascimento: new Date('0001-01-01'),
    genero: '',
    cpf: '',
    rg: '',
    ufDoRG: '',
    email: '',
    celular: '',
    telefoneFixo: '',
    convenioID: '',
    convenio: {
      id: '',
      nome: ''
    },
    carteirinhaDoConvenio: '',
    validadeDaCarteirinha: new Date('0001-01-01')
  };

  convenios: Convenio[] = [];

  constructor(private pacientesService: PacientesService, private conveniosService: ConveniosService, private router: Router) {}

  ngOnInit(): void {
    this.conveniosService.listar()
      .subscribe({
        next: (resposta) => {
          this.convenios = resposta;
        },
        error: (resposta) => {
          this.mensagens.push(resposta.error);
          console.log(resposta)
        }
      });
  }

  adicionar(){
    if(this.paciente.validadeDaCarteirinha != null
      && this.paciente.validadeDaCarteirinha != new Date('0001-01-01')){
      const [ano,mes] = this.paciente.validadeDaCarteirinha.toString().split('-');
      this.paciente.validadeDaCarteirinha = new Date(+ano,+mes-1,1);
    }

    this.pacientesService.adicionar(this.paciente)
      .subscribe({
        next: (resposta) => {
          this.router.navigate(['pacientes']);
        },
        error: (resposta) => {
          this.mensagens.push(resposta.error);
          console.log(resposta)
        }
      })
  }
}
