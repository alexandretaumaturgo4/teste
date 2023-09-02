import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaFisicaCriarComponent } from './pessoa-fisica-criar.component';

describe('PessoaFisicaCriarComponent', () => {
  let component: PessoaFisicaCriarComponent;
  let fixture: ComponentFixture<PessoaFisicaCriarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PessoaFisicaCriarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PessoaFisicaCriarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
