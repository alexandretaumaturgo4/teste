import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {Login} from "../models/login";
import {Observable, take, tap, map, BehaviorSubject} from "rxjs";
import {LoginResponse} from "../models/login-response";
import {HttpUtil} from "../../../shared/utils/http.util";
import {StorageService} from "../../../shared/services/via-cep/via-cep.service";
import {AUTH_CONFIG} from "../auth.config";
import {ERoles} from "../../../shared/models/Usuario/ERoles";
import {environment} from "../../../../environments/environment.development";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  isLogged: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private httpClient: HttpClient, private router: Router, private storageService: StorageService) {
  }

  public login(login: Login): Observable<LoginResponse> {
    return this.httpClient
      .post<LoginResponse>(`${environment.API_URL}Auth/login`, login)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result)),
        tap((loginResponse: LoginResponse) => loginResponse.token ? this.isLogged.next(true) : this.isLogged.next(false))
      );
  }

  public isAuthenticated(): boolean {
    return !!this.getToken();
  }

  public logout() {
    this.storageService.localClear();
    this.router.navigateByUrl('/');
    location.reload();
  }


  public setTokenLocalStorage(loginResponse: LoginResponse): void {
    this.storageService.localSetItem(AUTH_CONFIG.keyToken, loginResponse.token);
  }

  public setRoleLocalStorage(loginResponse: LoginResponse): void {
    this.storageService.localSetItem(AUTH_CONFIG.keyRole, loginResponse.role);
  }


  public setEmailLocalStorage(loginResponse: LoginResponse): void {
    this.storageService.localSetItem(AUTH_CONFIG.keyEmail, loginResponse.email);
  }


  public getToken(): any {
    return this.storageService.localGetItem(AUTH_CONFIG.keyToken);
  }

  public getUser(): any {
    return this.storageService.localGetItem(AUTH_CONFIG.keyUser);
  }

  public getUserEmail(): any {
    return this.storageService.localGetItem(AUTH_CONFIG.keyEmail);
  }

  public getUserRole(): ERoles {
    return this.storageService.localGetItem(AUTH_CONFIG.keyRole);
  }
}
