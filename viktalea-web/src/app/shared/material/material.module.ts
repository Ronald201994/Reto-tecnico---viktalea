import { NgModule } from '@angular/core';
import { MatCell, MatHeaderCell, MatRow, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
    imports: [
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule,
        MatFormFieldModule,
        MatInputModule,
        MatToolbarModule,
        MatSortModule,
        MatPaginatorModule,
        MatSnackBarModule,
        MatLabel,
        MatRow,
        MatIcon,
        MatCell,
        MatHeaderCell
    ],
    exports: [
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule,
        MatFormFieldModule,
        MatInputModule,
        MatToolbarModule,
        MatSortModule,
        MatPaginatorModule,
        MatSnackBarModule,
        MatLabel,
        MatRow,
        MatIcon,
        MatCell,
        MatHeaderCell
    ]
})
export class MaterialModule { }