import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  timeOut = 1500;
  actionButtonLabel = 'Ok';
  config: MatSnackBarConfig = {
    duration: 3000,
    horizontalPosition: 'right',
    verticalPosition: 'top',
  }
  constructor(private readonly snackBar: MatSnackBar) {
  }

  open(message: string, isSuccess: boolean) {
    if (isSuccess) this.config.panelClass = 'success';
    else this.config.panelClass = 'notSuccess';
    this.snackBar.open(message, 'Bezár', this.config);
  }
}
