using API.Common.Entity.Core;
using API.Repository.Interface.Core;

namespace API.Repository.Core
{
    public class PessoaRepository : Repository<Context, Pessoa>, IPessoaRepository
    {
        public PessoaRepository(
            Context context) : base(context)
        {
        }
    }
}
