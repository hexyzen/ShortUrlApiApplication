import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditShortUrlComponent } from './add-edit-shorturl.component';

describe('AddEditShorturlComponent', () => {
  let component: AddEditShortUrlComponent;
  let fixture: ComponentFixture<AddEditShortUrlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditShortUrlComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditShortUrlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
