using senai_pessoas_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Interfaces
{
    public class IMarcaRepository
    {
        List<Marca_Domain> Listar();

        Marca_Domain BuscarPorId(int idMarca);

        void Cadastrar(Marca_Domain novoMarca);

        void AtualizarIdUrl(int idMarca, Marca_Domain Marca);

        void Deletar(int idMarca);
    }
}
