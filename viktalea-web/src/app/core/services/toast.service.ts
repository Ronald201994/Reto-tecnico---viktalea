import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ToastComponent, ToastData } from '../../shared/components/toast/toast.component';

@Injectable({
    providedIn: 'root'
})
export class ToastService {
    constructor(private readonly snackBar: MatSnackBar) { }

    show(message: string, type: 'success' | 'error' | 'info' = 'success', duration = 3000) {
        const data: ToastData = { message, type };
        this.snackBar.openFromComponent(ToastComponent, {
            data,
            duration,
            horizontalPosition: 'right',
            verticalPosition: 'top',
            panelClass: []
        });
    }
}