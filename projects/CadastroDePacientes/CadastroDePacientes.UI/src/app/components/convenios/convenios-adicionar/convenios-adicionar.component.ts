import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Convenio } from 'src/app/models/convenio.model';
import { ConveniosService } from 'src/app/services/convenios.service';

@Component({
  selector: 'app-convenios-adicionar',
  templateUrl: './convenios-adicionar.component.html',
  styleUrls: ['./convenios-adicionar.component.css']
})

export class ConveniosAdicionarComponent implements OnInit{
  mensagens: string[] = [];

  convenio: Convenio = {
    id: '',
    nome: ''
  };

  constructor(private conveniosService: ConveniosService, private router: Router) {}

  ngOnInit(): void {
    
  }

  adicionar(){
    this.conveniosService.adicionar(this.convenio)
      .subscribe({
        next: (resposta) => {
          this.router.navigate(['convenios']);
        },
        error: (resposta) => {
          this.mensagens.push(resposta.error);
          console.log(resposta)
        }
      })
  }
}
