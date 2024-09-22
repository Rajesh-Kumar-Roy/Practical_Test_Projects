import { Customer } from "./customer.model";
import { SaleItem } from "./saleItem.model";

  export class Sale {
    id: number = 0;
    saleDate= new Date();
    customerId: number = 0;
    customer: Customer = new Customer();
    items: SaleItem[] = [new SaleItem()];
  }