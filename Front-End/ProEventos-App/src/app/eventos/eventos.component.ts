import { Component, EventEmitter, OnInit, Output, TemplateRef } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventosClicado?: Evento;

  public eventos: Evento[] =[];
  public eventosFiltrados:Evento[] =[];
  public abrirCard: boolean = false;
  private _filtroLista: string = '';
  public eventoClicado?:Evento;
  public fixed: string = '';
  public detalheEvento: boolean = false;

  modalRef?: BsModalRef;
  message?: string;

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value : string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  constructor(
    private toastr: ToastrService,
    private eventoService: EventoService,
    private modalService: BsModalService,
    private spinner: NgxSpinnerService
    ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public getEventos(): void{
     this.eventoService.getEvento().subscribe({
       next: (eventos:Evento[]) => {
        this.eventos = eventos
        this.eventosFiltrados = this.eventos
      },
       error: (error:any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos','Erro!')
       },
       complete: () => this.spinner.hide()
    });

  }

  public filtrarEventos(filtrarPor:string) : Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventosFiltrados.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1

    )
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O evento foi excluido com sucesso!', 'Sucesso!');
  }

  decline(): void {
    this.modalRef?.hide();

  }

  abrirModalCard(evento: Evento): void{
    this.eventoClicado = evento;
    this.abrirCard = true;
    this.fixed = 'fixed'
    this.detalheEvento = true;
    console.log(this.detalheEvento);

  }

  fecharModalCard(_abrirCard:boolean): void{
    // if(_abrirCard == undefined)
    // this.abrirCard = false;
    // else
    this.abrirCard = _abrirCard;

  }

  abrirModalAdd(){
    this.abrirCard = true;
    this.fixed = 'fixed'
    this.detalheEvento = false;
    console.log(this.detalheEvento);

  }
}
