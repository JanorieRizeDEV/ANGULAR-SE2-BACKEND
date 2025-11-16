import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Tarjeta {
  id?: number;
  titular: string;
  numeroTarjeta: string;
  fechaExpiracion: string;
  cvv: number | string; // acepta string temporalmente
}

@Injectable({
  providedIn: 'root'
})
export class TarjetaService {
  private apiUrl = 'http://localhost:5230/api/Tarjeta';

  constructor(private http: HttpClient) {}

  addTarjeta(tarjeta: Tarjeta): Observable<Tarjeta> {
    // Asegurar que cvv es número antes de enviar
    const payload = {
      ...tarjeta,
      cvv: Number(tarjeta.cvv)
    };

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Tarjeta>(this.apiUrl, payload, { headers });
  }
}