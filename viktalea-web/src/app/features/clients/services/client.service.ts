import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Client } from '../interfaces/client.interface';

@Injectable({
    providedIn: 'root'
})
export class ClientService {
    BaseApi: string = 'https://localhost:7261/api';
    baseUrl: string = 'clients';
    constructor(
        private _http: HttpClient
    ) { }

    getClients(ruc?: string | null, businessName?: string | null): Observable<Client[]> {
        let params = new HttpParams();

        if (ruc) {
            params = params.set('ruc', ruc);
        }
        if (businessName) {
            params = params.set('businessName', businessName);
        }

        return this._http.get<Client[]>(`${this.BaseApi}/${this.baseUrl}`, { params });
    }

    addClient(request: Client) {
        return this._http.post<number>(`${this.BaseApi}/${this.baseUrl}`, request).pipe(
            map((result: number) => {
                return result;
            })
        )
    }

    updateClient(request: Client) {
        return this._http.put<number>(`${this.BaseApi}/${this.baseUrl}`, request).pipe(
            map((result: number) => {
                return result;
            })
        )
    }

    deleteClient(id: number) {
        return this._http.delete<void>(`${this.BaseApi}/${this.baseUrl}/${id}`);
    }
}