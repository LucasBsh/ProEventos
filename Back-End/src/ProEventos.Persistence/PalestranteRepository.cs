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
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly ProEventoContext Context;

        public PalestranteRepository(ProEventoContext context)
        {
            Context = context;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = Context.Palestrantes
                .Include(p => p.RedeSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = Context.Palestrantes
          .Include(e => e.RedeSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
  

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestrantesId, bool includeEvento)
        {
            IQueryable<Palestrante> query = Context.Palestrantes
                .Include(e => e.RedeSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query
                .OrderBy(p => p.Id).Where(p => p.Id == palestrantesId);

            return await query.FirstOrDefaultAsync();
        }


    }
}
