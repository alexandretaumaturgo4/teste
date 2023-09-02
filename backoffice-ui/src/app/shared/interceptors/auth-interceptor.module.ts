import {HTTP_INTERCEPTORS} from "@angular/common/http";
import {NgModule} from "@angular/core";
import {AuthInterceptor} from "./auth-interceptor";

@NgModule({
  providers: [
    {
      multi: true,
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
    },
  ],
})
export class AuthInterceptorModule {}
