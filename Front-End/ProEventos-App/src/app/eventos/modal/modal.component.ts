import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Evento } from 'src/app/models/Evento';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit {

  @Input() evento?: Evento;
  @Output() estadoModal = new EventEmitter<boolean>();
  @Input() detalhesEvento: boolean = false;


  form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  abrirCard: boolean = false;
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    console.log(this.evento?.tema);
    this.validation();
  }

  fecharModalCard(){
    this.estadoModal.emit(this.abrirCard);
  }

  public validation(): void{
    this.form = this.fb.group({
      tema: ['' ,[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      qtdPessoas: ['' ,[Validators.required, Validators.max(120000)]],
      dataEvento: ['' ,Validators.required],
      local: ['' ,Validators.required],
      imagemURL: ['' ,Validators.required],
      telefone: ['' ,Validators.required],
      email: ['' ,[Validators.required, Validators.email]],
    })
  }

  public resetForm(){
    this.form.reset();
  }
}
