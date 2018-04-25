import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuLargeIconsComponent } from './menu-large-icons.component';

describe('MenuLargeIconsComponent', () => {
  let component: MenuLargeIconsComponent;
  let fixture: ComponentFixture<MenuLargeIconsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuLargeIconsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuLargeIconsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
