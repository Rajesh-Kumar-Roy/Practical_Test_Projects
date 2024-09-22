import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Sale } from '../../core/models/sale.model';
import { CommonModule } from '@angular/common';
import { SaleService } from '../../core/services/sale.service';
import { ProductService } from '../../core/services/product.service';
import { Product } from '../../core/models/product.model';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-sale',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule, FormsModule, BsDatepickerModule, RouterLink],
  templateUrl: './sale.component.html',
  styleUrl: './sale.component.css'
})
export class SaleComponent implements OnInit{
  saleForm!: FormGroup;
  productData: Product[] =[];

  constructor(
    private fb: FormBuilder,
    private _saleService: SaleService, 
    private _productService: ProductService,
    private toastr: ToastrService, 
    private router: Router
  ) {}

  ngOnInit(): void {
    this.intilializeForm();
    this.loadProducts();
    
  }

  private intilializeForm(){
    this.saleForm = this.fb.group({
      saleDate: ['', Validators.required],
      customer: this.fb.group({
        name: ['', [Validators.required, Validators.minLength(3)]],
        email: ['', [Validators.required, Validators.email]],
        phone: ['', [Validators.required,Validators.pattern('^((\\+91-?)|0)?[0-9]{10}$')]],
        address: ['', Validators.required]
      }),
      items: this.fb.array([this.createItem()])
    });
  }

  //  SaleItem form group
  createItem(): FormGroup {
    return this.fb.group({
      productId: ['', Validators.required],
      quantity: [0, [Validators.required, Validators.min(1)]],
      totalPrice: [0, Validators.required]
    });
  }

  private loadProducts(){
    this._productService.loadAll().subscribe((res: Product[])=>{
      this.productData = res;
      console.log(res);
    });
  }
  // items  FormArray
  get items(): FormArray {
    return this.saleForm.get('items') as FormArray;
  }

  
  addItem() {
    this.items.push(this.createItem());
  }


  removeItem(index: number) {
    this.items.removeAt(index);
  }
 

  onDropdownChange(event: any, index: number): void {
    console.log('Selected Value:', event.target.value);
    console.log(index);
    let itemFormGroup = this.items.at(index) as FormGroup;
    let quantityValue = itemFormGroup.controls['quantity'].value;
    if (quantityValue > 0){
      let productObj = this.productData.find(x => x.id === Number(event.target.value)) ;
      if(productObj){
        itemFormGroup.controls['totalPrice'].patchValue(productObj.price * Number(quantityValue));
       }
    }
  }

  onChange(event: any, index: number) {
    console.log("New value = " + event.target.value)
    console.log(index);
    
    let itemFormGroup = this.items.at(index) as FormGroup;
    let productValue = itemFormGroup.controls['productId'].value;
    if (productValue !== ''){
      itemFormGroup.controls['totalPrice'].setValue(0);
     let productObj = this.productData.find(x => x.id === Number(productValue)) ;

     if(productObj){
      itemFormGroup.controls['totalPrice'].patchValue(productObj.price * Number(event.target.value));
     }
    }
  };
  onSubmit() {
    if (this.saleForm.valid) {
      const sale: Sale = this.saleForm.value;
      this._saleService.post(sale).subscribe(res=>{
        this.toastr.success(res.message, res.statusCode);
        this.router.navigate(['/salelist']);
      })
    }
  }
}
