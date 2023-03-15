import { ErrorComponent } from './components/error/error.component';
import { PromotionsComponent } from './components/body/promotions/promotions.component';
import { TransactionsComponent } from './components/body/transactions/transactions.component';
import { ProductsComponent } from './components/body/products/products.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './components/body/home/home.component';


@NgModule({
  imports: [
    RouterModule.forRoot([
      {path: '', component: HomeComponent},
      {path: 'home', component: HomeComponent},
      {path: 'products', component: ProductsComponent},
      {path: 'transactions', component: TransactionsComponent},
      {path: 'promotions', component: PromotionsComponent},
      // {path: '', redirectTo: 'home', component: HomeComponent, pathMatch: 'full'},
      {path: '**', component: ErrorComponent},
    ]),
  ],
  exports: [RouterModule]
})

export class AppRoutingModule {}
