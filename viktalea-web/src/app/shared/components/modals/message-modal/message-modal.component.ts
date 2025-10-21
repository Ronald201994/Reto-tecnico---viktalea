import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface MessageModalData {
    title: string;
    message: string;
    type?: 'confirm' | 'error' | 'info'; // define tipo de modal
}

@Component({
    selector: 'app-message-modal',
    templateUrl: './message-modal.component.html',
    standalone: false,
    styleUrls: ['./message-modal.component.scss']
})
export class MessageModalComponent {
    constructor(
        private readonly dialogRef: MatDialogRef<MessageModalComponent>,
        @Inject(MAT_DIALOG_DATA) public data: MessageModalData
    ) { }

    confirm(): void {
        this.dialogRef.close(true);
    }

    cancel(): void {
        this.dialogRef.close(false);
    }
}