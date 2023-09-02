import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaJuridicaCriarComponent } from './pessoa-juridica-criar.component';

describe('PessoaJuridicaCriarComponent', () => {
  let component: PessoaJuridicaCriarComponent;
  let fixture: ComponentFixture<PessoaJuridicaCriarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PessoaJuridicaCriarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PessoaJuridicaCriarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
