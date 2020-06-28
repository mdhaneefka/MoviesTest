import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MLDashBoardComponent } from './mldash-board/mldash-board.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LayoutModule } from '@angular/cdk/layout';
import { LayoutComponent } from '../layout/layout.component';
import { MaterialModule } from '../material/material.module';
import 'hammerjs';
import {
  MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatDialogModule, MatListModule, MatProgressBarModule, MatInputModule, MatDatepickerModule,
  MatRadioModule, MatSlideToggleModule, MatNativeDateModule,
  MatTooltipModule,
  MatPaginatorModule
} from '@angular/material';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from '../navigation/header/header.component';
import { SidenavListComponent } from '../navigation/sidenav-list/sidenav-list.component';


@NgModule({
  declarations: [
    AppComponent,
    MLDashBoardComponent,
    LayoutComponent,
    HeaderComponent,
    SidenavListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    LayoutModule,
    //FlexLayoutModule,
    MaterialModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    HttpClientModule,
    MatDialogModule,
    MatProgressBarModule,
    MatPaginatorModule,
    MatInputModule,
    MatDatepickerModule,
    MatRadioModule, MatSlideToggleModule, MatNativeDateModule, MatTooltipModule, MatDialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
