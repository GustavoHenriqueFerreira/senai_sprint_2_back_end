using senai_pessoas_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Interfaces
{
    public class IVeiculoRepository
    {
        List<Veiculo_Domain> Listar();

        Veiculo_Domain BuscarPorId(int idVeiculo);

        void Cadastrar(Veiculo_Domain novoVeiculo);

        void AtualizarIdUrl(int idVeiculo, Veiculo_Domain veiculo);

        void Deletar(int idVeiculo);
    }
}
