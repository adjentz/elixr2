import { Component, HostBinding, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { AppService } from './services/app.service';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/mergeMap';

@Component({
  selector: 'body',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  @HostBinding("class.slideout-active")
  get slideoutActive(): boolean {
    return this.appService.slideoutActive;
  }

  constructor(private appService: AppService, private router: Router, private activatedRoute: ActivatedRoute, private titleService: Title) {
  }
  ngOnInit(): void {
    this.router.events
      .filter((event) => event instanceof NavigationEnd)
      .map(() => this.activatedRoute)
      .map((route) => {
        while (route.firstChild) route = route.firstChild;
        return route;
      })
      .filter((route) => route.outlet === 'primary')
      .mergeMap((route) => route.data)
      .subscribe((event) => {

        window.scrollTo(0, 0);

        let title = 'Elixr RPG';
        if (event['title']) {
          title += ` | ${event['title']}`;
        }

        this.titleService.setTitle(title);
      });
  }
  showNavBox = false;
  hamburgerClicked(): void {
    this.showNavBox = !this.showNavBox;
  }
  dismissNav(): void {
    this.showNavBox = false;
  }
}
