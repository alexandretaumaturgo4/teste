import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {PageHomeComponent} from './page-home/page-home.component';
import {PageErroComponent} from './page-erro/page-erro.component';
import {MatCardModule} from "@angular/material/card";
import {HomeRoutingModule} from "./home-routing.module";
import {MatButtonModule} from "@angular/material/button";
import {RouterLink} from "@angular/router";
import {MatToolbarModule} from "@angular/material/toolbar";


@NgModule({
  declarations: [
    PageHomeComponent,
    PageErroComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    HomeRoutingModule,
    MatButtonModule,
    RouterLink,
    MatToolbarModule
  ]
})
export class HomeModule {
}
