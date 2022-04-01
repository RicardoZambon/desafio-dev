import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { DirectivesModule } from '../directives/directives.module';

import { AppRoutingModule } from 'src/app/app-routing.module';
import { LoginInputComponent } from './login/login-input/login-input.component';
import { LogoutModalComponent } from './modals/logout-modal/logout-modal.component';
import { NavigationDrawerComponent } from './navigation/navigation-drawer/navigation-drawer.component';
import { NavigationItemComponent } from './navigation/navigation-item/navigation-item.component';
import { GridLoadingRendererComponent } from './grid/grid-loading-renderer-component/grid-loading-renderer.component';


@NgModule({
  declarations: [
    LoginInputComponent,
    LogoutModalComponent,
    NavigationDrawerComponent,
    NavigationItemComponent,
    GridLoadingRendererComponent,
  ],
  imports: [
    AppRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    DirectivesModule
  ],
  exports: [
    LoginInputComponent,
    LogoutModalComponent,
    NavigationDrawerComponent,
    NavigationItemComponent,
    GridLoadingRendererComponent,
  ]
})
export class ComponentsModule { }