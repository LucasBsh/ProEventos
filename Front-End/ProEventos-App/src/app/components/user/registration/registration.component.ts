import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidadeField } from 'src/app/helpers/ValidadeField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

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
      usuario: ['' ,[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      firstname: ['' ,[Validators.required,]],
      lastname: ['' ,Validators.required],
      email: ['' ,[Validators.required, Validators.email]],
      senha: ['' ,[Validators.required, Validators.minLength(6)]],
      confirmarSenha: ['' ,[Validators.required]],
      }, formOptions)
  }

  public resetForm(){
    this.form.reset();
  }

}
