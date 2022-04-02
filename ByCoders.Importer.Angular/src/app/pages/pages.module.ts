import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ComponentsModule } from './../shared/components/components.module';
import { LoginComponent } from './authentication/login/login.component';
import { ImporterComponent } from './importer/importer.component';
import { OperationsComponent } from './operations/operations.component';
import { AgGridModule } from 'ag-grid-angular';
import { OperationsFiltersComponent } from './operations/operations-filters/operations-filters.component';


@NgModule({
  declarations: [
    LoginComponent,
    ImporterComponent,
    OperationsComponent,
    OperationsFiltersComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ComponentsModule,
    AgGridModule.forRoot()
  ]
})
export class PagesModule { }