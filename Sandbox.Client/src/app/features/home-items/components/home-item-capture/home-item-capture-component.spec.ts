import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeItemCaptureComponentComponent } from './home-item-capture-component';

describe('HomeItemCaptureComponentComponent', () => {
  let component: HomeItemCaptureComponentComponent;
  let fixture: ComponentFixture<HomeItemCaptureComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeItemCaptureComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeItemCaptureComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
