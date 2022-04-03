import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { of, lastValueFrom } from 'rxjs';

import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { LogoutModalComponent } from 'src/app/shared/components/modals/logout-modal/logout-modal.component';
import { NavigationDrawerComponent } from 'src/app/shared/components/navigation/navigation-drawer/navigation-drawer.component';
import { MenuItem } from 'src/app/shared/models/navigation/menu-item';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent implements OnInit, AfterViewInit {
  
  @ViewChild('navigation') navigation!: NavigationDrawerComponent;
  @ViewChild('logoutModal') logoutModal!: LogoutModalComponent;


  constructor(private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {

  }

  async ngAfterViewInit(): Promise<void> {
    this.navigation.menus = await lastValueFrom(
      of([
        this.createMenuItem(1, 'home', 'Home', 'home'),
        this.createMenuItem(2, 'file-import', 'File importer', 'importer'),
        this.createMenuItem(3, 'rectangle-list', 'Operations', 'operations')
      ])
    );
  }


  logout(): void {
    this.logoutModal.show();
  }

  logoutConfirmed(): void {
    this.authenticationService.signOut();
  }

  private createMenuItem(id: number, icon: string, label: string, url: string | undefined = undefined, parent: MenuItem | null = null) {
    const menuItem = new MenuItem();

    menuItem.id = id;
    menuItem.icon = icon;
    menuItem.label = label;
    menuItem.url = url;

    menuItem.parent = parent;

    return menuItem;
  }
}