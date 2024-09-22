import { inject, Injectable } from '@angular/core';
import { MasterService } from './master/master.service';
import { environment } from '../../Environments/environment';
import { Sale } from '../models/sale.model';
import { Observable } from 'rxjs';
import { Invoice } from '../models/invoice.model';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  baseService = inject(MasterService);
  url = `${environment.apiUrl}sale`;
  constructor() { }
  
  post(obj: Sale): Observable<any>{
    return this.baseService.post<any>(this.url, obj);
  }

  loadInvoice(): Observable<Invoice[]>{
    return this.baseService.get<Invoice[]>(`${this.url}/GetSaleDetailsAsync`);
  }

  loadInvoiceByUserName(userName: string): Observable<Invoice[]>{
    return this.baseService.get<Invoice[]>(`${this.url}/GetSaleDetailsByCustomerNameAsync/${userName}`);
  }

  loadSaleCustomer(): Observable<Customer[]>{
    return this.baseService.get<Customer[]>(`${this.url}/GetSaleCustomerAsync`);
  }

  
}
