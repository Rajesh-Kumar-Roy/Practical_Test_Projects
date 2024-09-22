import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { SaleService } from '../../core/services/sale.service';
import { Invoice } from '../../core/models/invoice.model';
import { Customer } from '../../core/models/customer.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReportService } from '../../core/services/report.service';

@Component({
  selector: 'app-sale-list',
  standalone: true,
  imports: [RouterLink, CommonModule, FormsModule],
  templateUrl: './sale-list.component.html',
  styleUrl: './sale-list.component.css'
})
export class SaleListComponent implements OnInit{
  invoiceData: Invoice[]= [];
  customerData: Customer[]=[];
  searchTerm: string = '';
  isDownload: boolean = false;
  spinnerState: boolean[] = [];
  constructor(
    private _saleService: SaleService, 
    private _reportService: ReportService,
    private router: Router
  ) {
    this.spinnerState = new Array(this.customerData.length).fill(false);
  }


  ngOnInit(): void {
    this.loadInvoice();
    this.loadSaleCustomer();
  }

  private loadInvoice(){
    this._saleService.loadInvoice().subscribe((res: Invoice[])=>{
      this.invoiceData = res;
    });
  }

  onSearch(){
    if (this.searchTerm) {
      this._saleService.loadInvoiceByUserName(this.searchTerm).subscribe((res: Invoice[])=>{
        this.invoiceData = res;
      });
    }else{
      this.loadInvoice();
    }
    
  }
  onDownload(id: number, index: number){
    this.spinnerState[index] = true;
    this._reportService.getInvoiceReport(id).subscribe({
      next: (data: ArrayBuffer) => {
        const blob = new Blob([data], { type: 'application/pdf' });
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'Invoice.pdf';
        a.click();
        window.URL.revokeObjectURL(url);
        this.spinnerState[index] = false;
      },
      error: (err) => {
        this.spinnerState[index] = false;
        console.error('Error downloading PDF:', err);
      }
    })
  }

  private loadSaleCustomer(){
    this._saleService.loadSaleCustomer().subscribe((res: Customer[])=>{
      this.customerData = res;
    });
  }

}
