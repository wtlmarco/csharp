import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Convenio } from 'src/app/models/convenio.model';
import { ConveniosService } from 'src/app/services/convenios.service';

@Component({
  selector: 'app-convenios-remover',
  templateUrl: './convenios-remover.component.html',
  styleUrls: ['./convenios-remover.component.css']
})

export class ConveniosRemoverComponent implements OnInit{
  mensagens: string[] = [];

  convenio: Convenio = {
    id: '',
    nome: ''
  };

  constructor(private route: ActivatedRoute, 
    private conveniosService: ConveniosService, 
    private router: Router) {}

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
                console.log(resposta);
              }
            });
        }
      }
    })
  }

  remover(){
    this.conveniosService.remover(this.convenio.id)
      .subscribe({
        next: (resposta) => {
          this.router.navigate(['convenios']);
        },
        error: (resposta) => {
          this.mensagens.push('O Convênio não pode ser removido pois possui Pacientes cadastrados');
          console.log(resposta);
        }
      })
  }
}
