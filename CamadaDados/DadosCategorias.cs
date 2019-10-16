using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DadosCategorias
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

        // Consturtor com parametros para inserir

        public DadosCategorias(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        // Consturtor com parametros para Editar

        public DadosCategorias(int idCategoria, string nome, string descricao)
        {
            IdCategoria = idCategoria;
            Nome = nome;
            Descricao = descricao;
        }

        // Consturtor com parametros para Excluir

        public DadosCategorias(int idCategoria)
        {
            IdCategoria = idCategoria;
        }

        // Consturtor com parametros para buscar texto

        public DadosCategorias(string textoBuscar)
        {
            TextoBuscar = textoBuscar;
        }

        // Metodo de inserir 

        public string Inserir (DadosCategorias dadosCategorias)
        {
            string resp = "";

            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexao.CaminhoBanco;
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

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

                resp = sqlCommand.ExecuteNonQuery() == 1 ? "Ok" : "Registro nao foi inserido";

            }
            catch (Exception e )
            {
                resp = e.Message + " Erro na inserção !";
            }
            finally
            {
                if(sqlConnection.State == ConnectionState.Open) sqlConnection.Close(); // Verifica se a conexão com o banco esta aberta
            }

            return resp;
        }

        // Metodo de Editar

        public string Editar (DadosCategorias dadosCategorias)
        {
            string resp = "";

            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexao.CaminhoBanco;
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

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

                resp = sqlCommand.ExecuteNonQuery() == 1 ? "Ok" : "A edição não foi feita!";

            }
            catch (Exception e)
            {
                resp = e.Message + " Erro na edição!";
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close(); // Verifica se a conexão com o banco esta aberta
            }

            return resp;
        }

        // Metodo de Excluir 

        public string Excluir(DadosCategorias dadosCategorias)
        {
            string resp = "";

            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexao.CaminhoBanco;
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "spDeletarCategoria";
                sqlCommand.CommandType = CommandType.StoredProcedure; // Para avisar que é uma procedure

                SqlParameter parametroIdCategoria = new SqlParameter
                {
                    ParameterName = "@idCategoria",
                    SqlDbType = SqlDbType.Int,
                    Value = IdCategoria
                };

                sqlCommand.Parameters.Add(parametroIdCategoria);
                
                //Executar o comando

                resp = sqlCommand.ExecuteNonQuery() == 1 ? "Ok" : "A exclusão não foi feita!";

            }
            catch (Exception e)
            {
                resp = e.Message + " Erro na exclusão!";
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close(); // Verifica se a conexão com o banco esta aberta
            }

            return resp;
        }

        // Metodo Visualizar Categoria 

        public DataTable Visualizar()
        {
            DataTable dataTableResultado = new DataTable("Categoria");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexao.CaminhoBanco;
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "spVisualizarCategoria",
                    CommandType = CommandType.StoredProcedure
                };

                // Toda veez que for fazer uma consulta guardar informações e exibir em uma tabela usar o dataAdapter

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTableResultado);

            }
            catch (Exception)
            {
                dataTableResultado = null;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close(); // Verifica se a conexão com o banco esta aberta
            }
            return dataTableResultado;
        }

        // Metodo buscar nome 

        public DataTable BuscarNome(DadosCategorias dadosCategorias)
        {
            DataTable dataTableResultado = new DataTable("Categoria");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Conexao.CaminhoBanco;
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "spBuscarNome",
                    CommandType = CommandType.StoredProcedure
                };

                // Toda veez que for fazer uma consulta guardar informações e exibir em uma tabela usar o dataAdapter

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTableResultado);

                SqlParameter parametroTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textoBuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = TextoBuscar
                };
                sqlCommand.Parameters.Add(parametroTextoBuscar);
            }
            catch (Exception)
            {
                dataTableResultado = null;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close(); // Verifica se a conexão com o banco esta aberta
            }
            return dataTableResultado;
        }
    }
}
