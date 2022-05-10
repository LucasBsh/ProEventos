import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidadeField } from 'src/app/helpers/ValidadeField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }


  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{

    const formOptions: AbstractControlOptions = {
      validators: ValidadeField.MustMatch('senha','confirmarSenha')
    };

    this.form = this.fb.group({
      titulo: ['' ,[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      firstname: ['' ,[Validators.required,]],
      lastname: ['' ,Validators.required],
      email: ['' ,[Validators.required, Validators.email]],
      telefone: ['' ,Validators.required],
      funcao: ['' ,Validators.required],
      descricao: ['' ,[Validators.required, Validators.minLength(100)]],
      senha: ['' ,[Validators.required, Validators.minLength(6)]],
      confirmarSenha: ['' ,[Validators.required]],
      }, formOptions)
  }

  public resetForm(){
    this.form.reset();
  }


}
