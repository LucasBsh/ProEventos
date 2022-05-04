import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
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

  abrirCard: boolean = false;
  constructor() { }

  ngOnInit(): void {
    console.log(this.evento?.tema);
  }

  fecharModalCard(){
    this.estadoModal.emit(this.abrirCard);
  }

}
