import {Component, OnDestroy, OnInit} from "@angular/core";
import {AuthenticationService} from "../../../authentication/services/authentication.service";
import {ERoles} from "../../../../shared/models/Usuario/ERoles";

@Component({
  selector: 'app-layout-base',
  templateUrl: './layout-base.component.html',
  styleUrls: ['./layout-base.component.scss'],
  providers: [AuthenticationService]
})
export class LayoutBaseComponent implements OnInit, OnDestroy {
  username: string;
  role: string;
  public isAuthenticated: boolean;

  constructor(private authService: AuthenticationService) {
  }

  logout(){
    this.authService.logout();
  }

  ngOnDestroy(): void {
  }

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated();
    this.username = this.authService.getUserEmail()
    this.role = this.authService.getUserRole().toString();

  }


}
