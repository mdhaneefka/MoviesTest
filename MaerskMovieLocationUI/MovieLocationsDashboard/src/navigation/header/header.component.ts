import { Component, OnInit, Output, EventEmitter } from '@angular/core';
//export interface Region {
//  value: string;
//  viewValue: string;
//}
//export interface ProductType {
//  value: string;
//  viewValue: string;
//}
//declare const $: any;
//declare interface RouteInfo {
//    path: string;
//    title: string;
//    icon: string;
//    class: string;
//}
//export const ROUTES: RouteInfo[] = [
//  //{ path: '/home', title: 'Home',  icon: 'home', class: '' },
//  //{ path: '/user-profile', title: 'User Profile',  icon:'person', class: '' },
//  //{ path: '/table-list', title: 'Table List',  icon:'content_paste', class: '' },
//  //{ path: '/typography', title: 'Typography',  icon:'library_books', class: '' },
//  //{ path: '/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
//  //{ path: '/maps', title: 'Maps',  icon:'location_on', class: '' },
//  //{ path: '/notifications', title: 'Notifications',  icon:'notifications', class: '' },
//];
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  selRegion: any;
 
  @Output() public sidenavToggle = new EventEmitter();
 
  constructor() { }
  
  ngOnInit() {
  }
 
  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
 
}
