import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserResultComponent } from './userresult.component';

describe('ResultuiComponent', () => {
  let component: UserResultComponent;
  let fixture: ComponentFixture<UserResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserResultComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
