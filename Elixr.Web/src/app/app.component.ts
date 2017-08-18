import { Component, HostBinding } from '@angular/core';
import { AppService } from './services/app.service';

@Component({
  selector: 'body',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  @HostBinding("class.slideout-active")
  get slideoutActive():boolean {
    return this.appService.slideoutActive;
  }

  constructor(private appService:AppService) {
    
  }

  showNavBox = false;
  hamburgerClicked():void {
    this.showNavBox = !this.showNavBox;
  }
}
