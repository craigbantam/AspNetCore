import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeItemCaptureComponent } from './home-item-capture-component';

describe('HomeItemCaptureComponentComponent', () => {
  let component: HomeItemCaptureComponent;
  let fixture: ComponentFixture<HomeItemCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeItemCaptureComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeItemCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
