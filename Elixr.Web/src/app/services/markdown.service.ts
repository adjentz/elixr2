import { Injectable } from '@angular/core';
import * as marked from 'marked';

@Injectable()
export class MarkdownService {

  constructor() {

  }

  renderMarkdown(markDown: string): string {
    return marked(markDown);
  }
}