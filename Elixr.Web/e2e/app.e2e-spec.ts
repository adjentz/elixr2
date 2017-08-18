import { Elixr.WebPage } from './app.po';

describe('elixr.web App', () => {
  let page: Elixr.WebPage;

  beforeEach(() => {
    page = new Elixr.WebPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
