using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        public IEnumerable<Evento> _evento = new Evento[] {

            new Evento(){

                EventoId = 1,
                Tema = "Angular e .Net",
                Local = "Varginha",
                Lote = "1º lote",
                QtdPessoas = 230,
                DataEvento = DateTime.Now.ToString(),
                ImagemURL = "foto.png"

                },
                new Evento(){
                EventoId = 2,
                Tema = "aaaaaaaaaaaa",
                Local = "Tc",
                Lote = "4º lote",
                QtdPessoas = 5000,
                DataEvento = DateTime.Now.ToString(),
                ImagemURL = "foto2.png"
               }
        };


     
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Teste Post";
        }
    }
}
