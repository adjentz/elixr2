import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ITemplate } from '../../models/view-models';
import { TemplatesService } from '../services/templates.service';

@Component({
  selector: 'app-templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.css']
})
export class TemplatesComponent implements OnInit {

  @Input() onlyRaces?: boolean;
  @Input() onlyAcquireable?: boolean;
  @Input() forSelection: boolean;
  @Output() selected = new EventEmitter<ITemplate>();

  templates: ITemplate[];
  constructor(private templatesService: TemplatesService) { }

  ngOnInit() {
    this.searchTemplates();
  }

  async searchTemplates() {
    this.templates = await this.templatesService.searchTemplates(this.onlyRaces);
  }

  templateSelected(template: ITemplate): void {
    if (!this.forSelection) {
      return;
    }
    this.selected.emit(template);
  }
}
