import { inject, Injectable } from '@angular/core';
import { environment } from '../../Environments/environment';
import { MasterService } from './master/master.service';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseService = inject(MasterService);
  url = `${environment.apiUrl}product`;
  constructor() { }

  post(obj: Product): Observable<any>{
    return this.baseService.post<any>(this.url, obj);
  }

  loadAll():Observable<Product[]>{
    return this.baseService.get<Product[]>(this.url);
  }
 

}
