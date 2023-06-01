import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Convenio } from 'src/app/models/convenio.model';
import { ConveniosService } from 'src/app/services/convenios.service';

@Component({
  selector: 'app-convenios-atualizar',
  templateUrl: './convenios-atualizar.component.html',
  styleUrls: ['./convenios-atualizar.component.css']
})

export class ConveniosAtualizarComponent implements OnInit{
  mensagens: string[] = [];

  convenio: Convenio = {
    id: '',
    nome: ''
  };

  constructor(private route: ActivatedRoute, private conveniosService: ConveniosService, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.conveniosService.filtrarPorId(id)
            .subscribe({
              next: (resposta) => {
                this.convenio = resposta;
              },
              error: (resposta) => {
                this.mensagens.push(resposta.error);
                console.log(resposta)
              }
            });
        }
      }
    })
  }

  atualizar(){
    this.conveniosService.atualizar(this.convenio.id, this.convenio)
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
