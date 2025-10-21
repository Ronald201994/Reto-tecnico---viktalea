import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListClientComponent } from './pages/list/list-client-page.component';
import { SharedModule } from '../../shared/shared.module';
import { ClientsRoutingModule } from './clients-routing.module';
import { RegisterClientComponent } from './components/register/register-client.component';

@NgModule({
    declarations: [
        ListClientComponent,
        RegisterClientComponent
    ],
    imports: [
        CommonModule,
        ClientsRoutingModule,
        SharedModule
    ]
})
export class ClientsModule { }