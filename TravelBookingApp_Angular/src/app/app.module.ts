import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchComponent } from './search/search.component';
import { UserComponent } from './user/user.component';
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { UserService } from './user/service/user-service.service';
import { EdituserComponent } from './user/edituser/edituser.component';
import { AdduserComponent } from './user/adduser/adduser.component';
import { DeleteuserComponent } from './user/deleteuser/deleteuser.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    UserComponent,
    AdduserComponent,
    EdituserComponent,
    DeleteuserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [UserService, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
