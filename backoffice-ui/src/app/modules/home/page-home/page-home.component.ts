import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from "../../authentication/services/authentication.service";
import {ERoles} from "../../../shared/models/Usuario/ERoles";

@Component({
  selector: 'app-page-home',
  templateUrl: './page-home.component.html',
  styleUrls: ['./page-home.component.scss']
})
export class PageHomeComponent implements OnInit{

  userRole: string;

  constructor(private authService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.userRole = this.authService.getUserRole().toString();
    console.log(this.userRole.toString())
  }


  protected readonly ERoles = ERoles;
}
