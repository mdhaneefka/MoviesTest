import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule,MatTabsModule,MatSelectModule,MatOptionModule,MatToolbarModule, MatButtonModule, MatSidenavModule,
  MatIconModule, MatListModule, MatCardModule,MatTableModule,MatMenuModule, MatFormFieldControl,MatPaginatorModule,MatInputModule,
  MatDatepickerModule, MatRadioModule, MatSlideToggleModule, MatNativeDateModule, MatTooltipModule, MatDialogModule } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTabsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatCardModule,
    MatTableModule,
    MatMenuModule,
    MatPaginatorModule,
    
    MatInputModule, MatDatepickerModule, MatRadioModule, MatSlideToggleModule, MatNativeDateModule, MatTooltipModule, MatDialogModule
  ],
  exports: [
    CommonModule,
    MatTabsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatCardModule,
    MatTableModule,
    MatMenuModule,
    MatPaginatorModule,
    MatInputModule,MatDatepickerModule,MatRadioModule,MatSlideToggleModule,MatNativeDateModule,MatTooltipModule
  ],
})
export class MaterialModule { }
