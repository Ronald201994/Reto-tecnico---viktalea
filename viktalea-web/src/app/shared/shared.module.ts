import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';
import { MessageModalComponent } from './components/modals/message-modal/message-modal.component';
import { ToastComponent } from './components/toast/toast.component';

@NgModule({
    declarations: [
        MessageModalComponent,
        ToastComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
    ],
    exports: [
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
        MessageModalComponent,
        ToastComponent
    ]
})
export class SharedModule { }
