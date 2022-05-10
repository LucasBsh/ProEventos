import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.showMenu();
    this.showMenuRegistration();

  }
  showMenu() : boolean{
    return this.router.url != '/user/login';
  }

  showMenuRegistration() : boolean{
    return this.router.url != '/user/registration';
  }

}
