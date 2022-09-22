import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowShorturlComponent } from './show-shorturl.component';

describe('ShowShorturlComponent', () => {
  let component: ShowShorturlComponent;
  let fixture: ComponentFixture<ShowShorturlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowShorturlComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowShorturlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
