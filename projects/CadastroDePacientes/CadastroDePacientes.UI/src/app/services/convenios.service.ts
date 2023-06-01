import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

import { Convenio } from 'src/app/models/convenio.model';

@Injectable({
  providedIn: 'root'
})

export class ConveniosService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  listar(): Observable<Convenio[]>{
    return this.http.get<Convenio[]>(this.baseApiUrl + '/api/convenios');
  }

  filtrarPorId(id:string): Observable<Convenio>{
    return this.http.get<Convenio>(this.baseApiUrl + '/api/convenios/' + id);
  }

  adicionar(convenio: Convenio): Observable<Convenio>{
    convenio.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Convenio>(this.baseApiUrl + '/api/convenios', convenio);
  }

  atualizar(id:string, convenio: Convenio): Observable<Convenio>{
    return this.http.put<Convenio>(this.baseApiUrl + '/api/convenios/' + id, convenio);
  }

  remover(id:string): Observable<Convenio>{
    return this.http.delete<Convenio>(this.baseApiUrl + '/api/convenios/' + id);
  }
}
