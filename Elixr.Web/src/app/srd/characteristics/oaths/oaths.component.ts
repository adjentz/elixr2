import { Component, OnInit } from '@angular/core';
import { CharacteristicType } from '../../../../models/view-models';
@Component({
  selector: 'app-oaths',
  templateUrl: './oaths.component.html',
  styleUrls: ['./oaths.component.css']
})
export class OathsComponent implements OnInit {

  oaths = CharacteristicType.Oath;
  constructor() { }

  ngOnInit() {
  }

}
