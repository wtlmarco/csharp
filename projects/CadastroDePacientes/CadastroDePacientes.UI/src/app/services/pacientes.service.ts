import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

import { Paciente } from 'src/app/models/paciente.model';

@Injectable({
  providedIn: 'root'
})

export class PacientesService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  listar(): Observable<Paciente[]>{
    return this.http.get<Paciente[]>(this.baseApiUrl + '/api/pacientes');
  }

  filtrarPorId(id:string): Observable<Paciente>{
    return this.http.get<Paciente>(this.baseApiUrl + '/api/pacientes/' + id);
  }

  adicionar(paciente: Paciente): Observable<Paciente>{
    paciente.id = '00000000-0000-0000-0000-000000000000';
    paciente.convenio.id = '00000000-0000-0000-0000-000000000000';

    paciente.convenioID = (paciente.convenioID.trim().length == 0) ? '00000000-0000-0000-0000-000000000000' : paciente.convenioID;
    
    return this.http.post<Paciente>(this.baseApiUrl + '/api/pacientes', paciente);
  }

  atualizar(id:string, paciente: Paciente): Observable<Paciente>{
    if(paciente.convenio != null) 
      paciente.convenio.id = '00000000-0000-0000-0000-000000000000';

    if(paciente.convenioID != null)
      paciente.convenioID = (paciente.convenioID.trim().length == 0) ? '00000000-0000-0000-0000-000000000000' : paciente.convenioID;
    
    return this.http.put<Paciente>(this.baseApiUrl + '/api/pacientes/' + id, paciente);
  }
}
