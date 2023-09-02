import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoasListarComponent } from './pessoas-listar.component';

describe('PessoasListarComponent', () => {
  let component: PessoasListarComponent;
  let fixture: ComponentFixture<PessoasListarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PessoasListarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PessoasListarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
