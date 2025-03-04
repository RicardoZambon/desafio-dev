import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from './shared/auth.guard';

import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { AppComponent } from './app.component';
import { ImporterComponent } from './pages/importer/importer.component';
import { OperationsComponent } from './pages/operations/operations.component';

import { LoginLayoutComponent } from './layout/login-layout/login-layout.component';
import { LoginComponent } from './pages/authentication/login/login.component';

import { JwtModule } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: 'home', component: AppComponent },
      { path: 'importer', component: ImporterComponent },
      { path: 'operations', component: OperationsComponent },
    ],
    canActivate: [ AuthGuard ]
  },
  {
    path: '',
    component: LoginLayoutComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent }
    ]
  }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes, {
          scrollPositionRestoration: 'enabled'
        }),
        JwtModule.forRoot({
          config: {
            tokenGetter: () => localStorage.getItem("jwt"),
            allowedDomains: [
              environment.apiUrl.replace(/(^\w+:|^)\/\//, '')
            ],
            disallowedRoutes: [
              `${environment.apiUrl}/Authentication/RefreshToken`,
              `${environment.apiUrl}/Authentication/SignIn`
            ]
          }
        })
      ],
      exports: [RouterModule]
})
export class AppRoutingModule { }