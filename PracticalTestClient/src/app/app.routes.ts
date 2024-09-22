import { Routes } from '@angular/router';
import { PageNotFoundComponent } from './core/components/page-not-found/page-not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { SaleComponent } from './pages/sale/sale.component';
import { ProductListComponent } from './pages/product-list/product-list.component';
import { ProductComponent } from './pages/product/product.component';
import { SaleListComponent } from './pages/sale-list/sale-list.component';

export const routes: Routes = [
  
    { path: 'home', component: HomeComponent},
    { path: 'product', component: ProductComponent},
    { path: 'productlist', component: ProductListComponent},
    { path: 'sale', component: SaleComponent},
    { path: 'salelist', component: SaleListComponent},
    { path: '',   redirectTo: 'home', pathMatch: 'full' }, // redirect to `first-component`
    { path: '**', component: PageNotFoundComponent},
];
