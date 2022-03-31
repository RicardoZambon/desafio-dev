import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from '../app-routing.module';
import { ComponentsModule } from './../shared/components/components.module';
import { LoginLayoutComponent } from './login-layout/login-layout.component';


@NgModule({
  declarations: [
    LoginLayoutComponent
  ],
  imports: [
    AppRoutingModule,
    CommonModule,
    ComponentsModule
  ]
})
export class LayoutModule { }