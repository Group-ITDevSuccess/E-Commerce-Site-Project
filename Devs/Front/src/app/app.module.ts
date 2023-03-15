import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './components/header/navbar/navbar.component';
import { SocialsComponent } from './components/footer/socials/socials.component';
import { HomeComponent } from './components/body/home/home.component';
import { ProductsComponent } from './components/body/products/products.component';
import { TransactionsComponent } from './components/body/transactions/transactions.component';
import { PromotionsComponent } from './components/body/promotions/promotions.component';
import { ErrorComponent } from './components/error/error.component';
import { DropdownComponent } from './components/header/dropdown/dopdown.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SocialsComponent,
    DropdownComponent,
    HomeComponent,
    ProductsComponent,
    TransactionsComponent,
    PromotionsComponent,
    ErrorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
