import { Component, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

export interface ToastData {
    message: string;
    type?: 'success' | 'error' | 'info';
}

@Component({
    selector: 'app-toast',
    templateUrl: './toast.component.html',
    standalone: false,
    styleUrls: ['./toast.component.scss']
})
export class ToastComponent {
    constructor(@Inject(MAT_SNACK_BAR_DATA) public data: ToastData) { }
}