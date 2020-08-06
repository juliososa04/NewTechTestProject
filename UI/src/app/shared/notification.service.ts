import { Injectable } from '@angular/core';
 import {MatSnackBar,MatSnackBarConfig} from '@angular/material';
import { config } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(public snackbar:MatSnackBar) { }
  config: MatSnackBarConfig={
    verticalPosition:'top',
    horizontalPosition:'right',
    duration:2000
  }
  success(msg){
    this.config.panelClass=['success','notification']
    this.snackbar.open(msg,'',this.config);
  }
  warn(msg){
    this.config.panelClass=['warn','notification']
    this.snackbar.open(msg,'',this.config);
  }
}
