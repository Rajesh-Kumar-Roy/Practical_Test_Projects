import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../Environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  url = `${environment.apiUrl}sale`;

  constructor(private _http: HttpClient) { }

  getInvoiceReport(id: number): Observable<ArrayBuffer>{
    let  headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.get<any>(`${environment.apiUrl}Report/Invice/pdf/${id}`, { responseType: 'arraybuffer' as 'json' });
  }

}
