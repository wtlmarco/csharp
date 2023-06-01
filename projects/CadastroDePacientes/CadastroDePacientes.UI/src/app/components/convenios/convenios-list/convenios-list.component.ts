import { Component, OnInit } from '@angular/core';

import { Convenio } from 'src/app/models/convenio.model';
import { ConveniosService } from 'src/app/services/convenios.service';

@Component({
  selector: 'app-convenio-list',
  templateUrl: './convenios-list.component.html',
  styleUrls: ['./convenios-list.component.css']
})

export class ConveniosListComponent implements OnInit {
  
  convenios: Convenio[] = [];

  constructor(private conveniosService: ConveniosService) {}

  ngOnInit(): void {
    this.conveniosService.listar()
      .subscribe({
        next: (resposta) => {
          this.convenios = resposta;
        },
        error: (resposta) => {
          console.log(resposta)
        }
      });
  }
}
