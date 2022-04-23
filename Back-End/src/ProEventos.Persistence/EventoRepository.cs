using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ProEventoContext Context;

        public EventoRepository(ProEventoContext context)
        {
            Context = context;

            //comentado porque será usado AsNoTracking nos métodos especificos, caso precise usar para
            //todos descomentar.

            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = Context.Eventos
                .Include(e => e.Lote)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = Context.Eventos
                .Include(e => e.Lote)
                .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = Context.Eventos
               .Include(e => e.Lote)
               .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
