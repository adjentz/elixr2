import { Component, OnInit, Input, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { MarkdownService } from '../../services/markdown.service';

@Component({
  selector: 'app-markdown-editor',
  templateUrl: './markdown-editor.component.html',
  styleUrls: ['./markdown-editor.component.less']
})
export class MarkdownEditorComponent implements OnInit {

  private editing = false;
  private _model = "";
  renderedModel = "";

  @ViewChild("editTextarea") descriptionTextarea: ElementRef;
  @Output() modelChange = new EventEmitter<string>();
  @Input() canEdit = true;
  @Input()
  get model(): string {
    return this._model;
  }
  set model(value: string) {
    if (this._model !== value) {
      this._model = value;
      this.renderedModel = this.markdownService.renderMarkdown(value);
      this.modelChange.emit(value);
    }
  }

  constructor(private markdownService: MarkdownService) { }

  ngOnInit() {
  }
  renderedMarkdownClicked(): void {
    if (!this.canEdit) {
      this.editing = false;
      return;
    }
    this.editing = true;
    setTimeout(() => this.descriptionTextarea.nativeElement.focus(), 0);
  }
}
