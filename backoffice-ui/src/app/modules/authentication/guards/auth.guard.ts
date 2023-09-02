import {
  CanActivate,
  CanLoad, Router,
} from "@angular/router";
import {AuthenticationService} from "../services/authentication.service";
import {StorageService} from "../../../shared/services/via-cep/via-cep.service";
import {AUTH_CONFIG} from "../auth.config";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanLoad, CanActivate {
  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private storageService: StorageService
  ) {
  }


  canLoad(): boolean {
    return this.canAccess();
  }

  canActivate(): boolean {
    return this.canAccess();
  }

  private canAccess(): boolean {
    if (!this.authService.isAuthenticated()) {
      this.router.navigateByUrl(
        `${AUTH_CONFIG.pathFront}/login`
      );

      return false;
    }

    return true;
  }
}
