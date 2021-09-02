using senai_pessoas_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Interfaces
{
    public class IModeloRepository
    {
        List<Modelo_Domain> Listar();

        Modelo_Domain BuscarPorId(int idModelo);

        void Cadastrar(Modelo_Domain novoModelo);

        void AtualizarIdUrl(int idModelo, Modelo_Domain modelo);

        void Deletar(int idModelo);
    }
}
