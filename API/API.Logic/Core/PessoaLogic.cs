using API.Common.Entity.Core;
using API.Logic.Interface.Core;
using API.Repository.Interface.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Logic.Core
{
    public class PessoaLogic : Logic<IPessoaRepository, Pessoa>, IPessoaLogic
    {
        IPessoaRepository _pessoaRepository;

        public PessoaLogic(IPessoaRepository pessoaRepository) : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
    }
}
