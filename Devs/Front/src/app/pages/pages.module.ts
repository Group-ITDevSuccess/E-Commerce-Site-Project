import { NgModule } from "@angular/core";
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products.component';
import { UsersComponent } from './users/users.component';
import { CustomersComponent } from './customers/customers.component';
import { OrdersComponent } from './orders/orders.component';
import { ClientsComponent } from './clients/clients.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { BrowserModule } from "@angular/platform-browser";
import { SharedModule } from "../themes/shared/shared.module";

@NgModule({
  imports: [BrowserModule, SharedModule],
  exports: [],
  declarations: [HomeComponent, ProductsComponent, UsersComponent, CustomersComponent, OrdersComponent, ClientsComponent, DashboardComponent, LoginComponent, SignupComponent],
  providers: []
})

export class PagesModule {}
