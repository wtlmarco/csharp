import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'CadastroDePacientes.UI';

  hoje: string = '';

  constructor(){}

  ngOnInit() : void {
    this.hoje = new Date().toISOString().split('T')[0];
  }
}
