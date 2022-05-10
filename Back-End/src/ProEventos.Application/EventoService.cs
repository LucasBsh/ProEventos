using ProEventos.Persistence.Repository;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using AutoMapper;

namespace ProEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public EventoService(IGeralRepository geralRepository, IEventoRepository eventoRepository, IMapper mapper)
        {
            _geralRepository = geralRepository;
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }
        public async Task<EventoDTO> AddEventos(EventoDTO model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _geralRepository.Add<Evento>(evento);
                if (await _geralRepository.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoRepository.GetEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDTO>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoDTO> UpdateEventos(int eventoId, EventoDTO model)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _geralRepository.Update<Evento>(evento);


                if (await _geralRepository.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoRepository.GetEventoByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDTO>(eventoRetorno); 
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {

            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync( eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não foi Encontrado.");


                _geralRepository.Delete<Evento>(evento);
                return await _geralRepository.SaveChangesAsync();
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDTO[]>(eventos);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDTO[]>(eventos);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDTO> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null) return null;

                var resultado = _mapper.Map<EventoDTO>(evento);

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
