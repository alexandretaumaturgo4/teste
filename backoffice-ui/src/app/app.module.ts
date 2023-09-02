import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {LayoutComponentsModule} from "./modules/layout/components/layout-component.module";
import {HttpClientModule} from "@angular/common/http";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {AuthInterceptorModule} from "./shared/interceptors/auth-interceptor.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutComponentsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSnackBarModule,
    AuthInterceptorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
