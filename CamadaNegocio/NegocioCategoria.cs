using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaNegocio
{
    public class NegocioCategoria // Public para poder ser chamado externamente
    {
        // Metodo inserir

        public static string Inserir(string nome, string descricao)
        {
            DadosCategorias dadosCategorias = new DadosCategorias(nome, descricao);
            return dadosCategorias.Inserir(dadosCategorias);
        }

        // Metodo Editar

        public static string Editar(int idCategoria, string nome, string descricao)
        {
            DadosCategorias dadosCategorias = new DadosCategorias(idCategoria, nome, descricao);
            return dadosCategorias.Editar(dadosCategorias);
        }

        // Metodo Excluir

        public static string Excluir(int idCategoria)
        {
            DadosCategorias dadosCategorias = new DadosCategorias(idCategoria);
            return dadosCategorias.Excluir(dadosCategorias);
        }

        //Metodo Mostrar

        public static DataTable Visualisar()
        {
            return new DadosCategorias().Visualizar();
        }

        //Metodo Buscar nome

        public static DataTable BuscarNome(string textoBuscar)
        {
            DadosCategorias dadosCategorias = new DadosCategorias(textoBuscar);
            return dadosCategorias.BuscarNome(dadosCategorias);
        }
    }
}
