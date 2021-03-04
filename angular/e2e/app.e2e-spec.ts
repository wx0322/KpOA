import { FunOATemplatePage } from './app.po';

describe('FunOA App', function() {
  let page: FunOATemplatePage;

  beforeEach(() => {
    page = new FunOATemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
