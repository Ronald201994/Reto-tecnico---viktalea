import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MessageModalComponent, MessageModalData } from '../../shared/components/modals/message-modal/message-modal.component';

@Injectable({
    providedIn: 'root'
})
export class MessageModalService {
    constructor(private readonly dialog: MatDialog) { }

    /** Modal de confirmación */
    async confirm(title: string, message: string): Promise<boolean> {
        const result = await this.dialog.open(MessageModalComponent, {
            width: '400px',
            data: { title, message, type: 'confirm' } as MessageModalData
        }).afterClosed().toPromise();
        return !!result;
    }

    /** Modal de información o error */
    async showMessage(title: string, message: string, type: 'info' | 'error' = 'info'): Promise<void> {
        await this.dialog.open(MessageModalComponent, {
            width: '400px',
            data: { title, message, type } as MessageModalData
        }).afterClosed().toPromise();
    }
}