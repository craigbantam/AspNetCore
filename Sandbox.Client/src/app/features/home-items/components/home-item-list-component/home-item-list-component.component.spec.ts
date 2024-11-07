import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeItemListComponentComponent } from './home-item-list-component.component';

describe('HomeItemListComponentComponent', () => {
  let component: HomeItemListComponentComponent;
  let fixture: ComponentFixture<HomeItemListComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeItemListComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeItemListComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
