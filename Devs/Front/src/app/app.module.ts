import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './themes/layout/admin/header/header.component';
import { FooterComponent } from './themes/layout/admin/footer/footer.component';
import { PagesModule } from './pages/pages.module';
import { SharedModule } from './themes/shared/shared.module';
import { AppRoutingModule } from './app.routing';
import { AppUserService } from './@core/services/admin/app-user.service';
import { ApiAppUser } from './services/admin/api-app-user';
import { ApiService } from './@core/services/api.service';
import { UserFormatPipe } from './themes/shared/pipe/user-format.pipe';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    AppRoutingModule,
    HttpClientModule,
    BrowserModule,
    PagesModule,
    SharedModule,

  ],
  providers: [{provide: AppUserService, useClass:  ApiAppUser}, ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
