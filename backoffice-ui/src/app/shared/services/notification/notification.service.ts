import {Injectable} from "@angular/core";
import {ToastrService} from "ngx-toastr";
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(private snackBar: MatSnackBar) {
  }

  public error(value: string): void {
    this.snackBar.open(value, 'fechar', {
      duration: 3000,
      panelClass: ['snackbar-error']
    });
  }

  public success(value: string): void {
    this.snackBar.open(value, 'fechar', {
      duration: 3000,
      panelClass: ['snackbar-success']
    });
  }


}
