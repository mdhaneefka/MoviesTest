import { Component, OnInit, Output, EventEmitter } from '@angular/core';
export interface Region {
  value: string;
  viewValue: string;
}
export interface ProductType {
  value: string;
  viewValue: string;
} 
@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.css']
})
export class SidenavListComponent implements OnInit {

  //panelOpenState = false;

  @Output() sidenavClose = new EventEmitter();
 
  constructor() { }

  ngOnInit() {
  }
 
  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }
 
}
