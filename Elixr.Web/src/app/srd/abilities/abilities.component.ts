import { Component, OnInit } from '@angular/core';
import { ElixrService } from '../../services/elixr.service';
@Component({
  selector: 'app-abilities',
  templateUrl: './abilities.component.html',
  styleUrls: ['./abilities.component.less']
})
export class AbilitiesComponent implements OnInit {
  scores: number[];
  constructor(private elixrService: ElixrService) { 
    this.scores = [];
  }

  ngOnInit() {
    for (var i = 0; i < 20; i++) {
      this.scores.push(i + 1);
    }
  }

  modForScore(score: number): number {
    return this.elixrService.calculateModifier(score);
  }

}
