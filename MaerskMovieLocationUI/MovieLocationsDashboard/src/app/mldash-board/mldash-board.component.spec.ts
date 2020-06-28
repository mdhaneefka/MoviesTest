import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MLDashBoardComponent } from './mldash-board.component';

describe('MLDashBoardComponent', () => {
  let component: MLDashBoardComponent;
  let fixture: ComponentFixture<MLDashBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MLDashBoardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MLDashBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
