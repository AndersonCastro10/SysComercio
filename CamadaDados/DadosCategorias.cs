using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    class DadosCategorias
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TextoBuscar { get; set; }

        // Construtor vazio 

        public DadosCategorias() { }

        // Consturtor com parametros

        public DadosCategorias(int idCategoria, string nome, string descricao, string textoBuscar)
        {
            IdCategoria = idCategoria;
            Nome = nome;
            Descricao = descricao;
            TextoBuscar = textoBuscar;
        }

        // Metodo de inserir 

        public string Inserir (DadosCategorias dadosCategorias)
        {
            string resp = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexao.CaminhoBanco;
                sqlCon.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                sqlCommand.CommandText = "spInserirCategoria";
                sqlCommand.CommandType = CommandType.StoredProcedure; // Para avisar que é uma procedure

                SqlParameter parametroIdCategoria = new SqlParameter
                {
                    ParameterName = "@idCategoria",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                sqlCommand.Parameters.Add(parametroIdCategoria);

                SqlParameter parametroNome = new SqlParameter
                {
                    ParameterName = "@nome",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Nome
                };

                sqlCommand.Parameters.Add(parametroNome);

                SqlParameter parametroDecricao = new SqlParameter
                {
                    ParameterName = "@descricao",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Descricao
                };

                sqlCommand.Parameters.Add(parametroDecricao);

                //Executar o comando

                return resp = sqlCommand.ExecuteNonQuery() == 1 ? "Ok" : "Registro nao foi inserido";

            }
            catch (Exception e )
            {
                return resp = e.Message + " Erro na inserção !";
            }
            finally
            {
                if(sqlCon.State == ConnectionState.Open) sqlCon.Close(); // Verifica se a conexão com o banco esta aberta
            }
        }

        // Metodo de Editar

        public string Editar (DadosCategorias dadosCategorias)
        {
            string resp = "";

            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = Conexao.CaminhoBanco;
                sqlCon.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlCon;

                sqlCommand.CommandText = "spInserirCategoria";
                sqlCommand.CommandType = CommandType.StoredProcedure; // Para avisar que é uma procedure

                SqlParameter parametroIdCategoria = new SqlParameter
                {
                    ParameterName = "@idCategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = IdCategoria
                };

                sqlCommand.Parameters.Add(parametroIdCategoria);

                SqlParameter parametroNome = new SqlParameter
                {
                    ParameterName = "@nome",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Nome
                };

                sqlCommand.Parameters.Add(parametroNome);

                SqlParameter parametroDecricao = new SqlParameter
                {
                    ParameterName = "@descricao",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Descricao
                };

                sqlCommand.Parameters.Add(parametroDecricao);

                //Executar o comando

                return resp = sqlCommand.ExecuteNonQuery() == 1 ? "Ok" : "A edição não foi feita!";

            }
            catch (Exception e)
            {
                return resp = e.Message + " Erro na edição!";
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close(); // Verifica se a conexão com o banco esta aberta
            }
        }

        // Metodo de Excluir 

        public string Excluir(DadosCategorias dadosCategorias)
        {

        }

        // Metodo Mostrar 

        public DataTable Mostrar (DadosCategorias dadosCategorias)
        {

        }

        // Metodo buscar nome 

        public string BuscarNome(DadosCategorias dadosCategorias)
        {

        }
    }
}
