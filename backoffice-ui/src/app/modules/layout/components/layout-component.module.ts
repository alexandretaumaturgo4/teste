import {CommonModule} from "@angular/common";
import {RouterModule} from "@angular/router";
import {NgModule} from "@angular/core";
import {LayoutBaseComponent} from "./layout-base/layout-base.component";
import {MatIconModule} from "@angular/material/icon";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {MatListModule} from "@angular/material/list";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatCardModule} from "@angular/material/card";

@NgModule({
  declarations: [LayoutBaseComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule
  ],
  exports: [LayoutBaseComponent],
})
export class LayoutComponentsModule {
}
