import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClientService } from '../../services/client.service';
import { Client } from '../../interfaces/client.interface';
import { ToastService } from '../../../../core/services/toast.service';

@Component({
    selector: 'app-register-client',
    templateUrl: './register-client.component.html',
    styleUrls: ['./register-client.component.scss'],
    standalone: false
})
export class RegisterClientComponent {
    clientForm: FormGroup;

    constructor(
        private readonly fb: FormBuilder,
        private readonly clientService: ClientService,
        private readonly toast: ToastService,
        private readonly dialogRef: MatDialogRef<RegisterClientComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { client: Client | null }
    ) {
        this.clientForm = this.fb.group({
            ruc: [
                data.client?.ruc || '',
                [Validators.required, Validators.minLength(11), Validators.maxLength(11)]
            ],
            businessName: [data.client?.businessName || '', Validators.required],
            contactPhone: [data.client?.contactPhone || '', Validators.required],
            contactEmail: [
                data.client?.contactEmail || '',
                [Validators.required, Validators.email]
            ],
            address: [data.client?.address || '']
        });
    }

    async save(): Promise<void> {
        if (this.clientForm.invalid) {
            this.clientForm.markAllAsTouched(); // muestra errores
            return;
        }

        const clientData: Client = {
            ...this.data.client,
            ...this.clientForm.value
        } as Client;

        try {
            if (this.data.client) {
                await this.clientService.updateClient(clientData).toPromise();
                this.toast.show('Cliente actualizado correctamente', 'success');
            } else {
                await this.clientService.addClient(clientData).toPromise();
                this.toast.show('Cliente registrado correctamente', 'success');
            }
            this.dialogRef.close(true);
        } catch (error) {
            console.error('Error guardando cliente:', error);
            this.toast.show('Ocurrió un error al guardar el cliente', 'error');
        }
    }

    cancel(): void {
        this.dialogRef.close(false);
    }
}