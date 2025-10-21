import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormControl } from '@angular/forms';
import { Subscription, debounceTime, distinctUntilChanged } from 'rxjs';
import { Client } from '../../interfaces/client.interface';
import { ClientService } from '../../services/client.service';
import { MatTableDataSource } from '@angular/material/table';
import { RegisterClientComponent } from '../../components/register/register-client.component';
import { MessageModalService } from '../../../../core/services/message-modal.service';
import { ToastService } from '../../../../core/services/toast.service';

@Component({
    selector: 'app-list-client-wrapper',
    templateUrl: './list-client-page.component.html',
    styleUrls: ['./list-client-page.component.scss'],
    standalone: false
})
export class ListClientComponent implements OnInit, OnDestroy {
    private dataSubscription: Subscription = Subscription.EMPTY;

    clients: Client[] = [];
    displayedColumns: string[] = ['ruc', 'businessName', 'contactPhone', 'contactEmail', 'address', 'actions'];
    dataSource = new MatTableDataSource<Client>();

    // Filtros reactivos
    rucFilter = new FormControl('');
    businessNameFilter = new FormControl('');

    constructor(
        private readonly clientService: ClientService,
        private readonly dialog: MatDialog,
        private readonly messageModal: MessageModalService,
        private readonly toast: ToastService
    ) { }

    ngOnInit(): void {
        this.loadClients();

        // Suscribimos los filtros con debounce
        this.rucFilter.valueChanges.pipe(
            debounceTime(500),
            distinctUntilChanged()
        ).subscribe(() => this.loadClients());

        this.businessNameFilter.valueChanges.pipe(
            debounceTime(500),
            distinctUntilChanged()
        ).subscribe(() => this.loadClients());
    }

    private loadClients(): void {
        const ruc = this.rucFilter.value?.trim() || null;
        const businessName = this.businessNameFilter.value?.trim() || null;

        this.dataSubscription = this.clientService.getClients(ruc, businessName).subscribe(result => {
            this.clients = result;
            this.dataSource.data = result;
        });
    }

    openCreateDialog(): void {
        const dialogRef = this.dialog.open(RegisterClientComponent, {
            width: '450px',
            data: { client: null }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) this.loadClients();
        });
    }

    openEditDialog(client: Client): void {
        const dialogRef = this.dialog.open(RegisterClientComponent, {
            width: '450px',
            data: { client }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) this.loadClients();
        });
    }

    async deleteClient(client: Client): Promise<void> {
        // Usamos el modal de confirmación
        const confirmed = await this.messageModal.confirm(
            'Eliminar Cliente',
            `¿Eliminar cliente ${client.businessName}?`
        );

        if (!confirmed) return;

        // Eliminamos el cliente y mostramos toast
        this.clientService.deleteClient(client.id).subscribe({
            next: () => {
                this.loadClients();
                this.toast.show('Cliente eliminado correctamente', 'success');
            },
            error: () => this.toast.show('Error al eliminar cliente', 'error')
        });
    }

    ngOnDestroy(): void {
        this.dataSubscription.unsubscribe();
    }
}