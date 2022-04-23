using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Repository
{
    public interface IPalestranteRepository
    {
        //palestrante

        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEvento);
        Task<Palestrante[]> GetAllPalestranteAsync( bool includeEvento);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestrantesId, bool includeEvento);

    }
}
