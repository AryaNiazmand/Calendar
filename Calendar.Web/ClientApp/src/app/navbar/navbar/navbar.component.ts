import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass']
})
export class NavbarComponent implements OnInit{
  
  items!: MenuItem[];

  constructor() {}

  ngOnInit(): void {
    this.items = [
      {label: 'Home',routerLink:"\home", icon: 'pi pi-fw pi-home'},
      {label: 'Calendar',routerLink:"\calendar", icon: 'pi pi-fw pi-calendar'},
      {label: 'About',routerLink:"\about", icon: 'pi pi-fw pi-pencil'},
  ];
  }

}
