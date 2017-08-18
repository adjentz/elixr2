import { Injectable } from '@angular/core';

@Injectable()
export class AppService {

  slideoutActive = false;

  constructor() { }

  showSlideout():void {
    this.slideoutActive = true;
  }
  dismissSlideout():void {
    this.slideoutActive = false;
  }

}
