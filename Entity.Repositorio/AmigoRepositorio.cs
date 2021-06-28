using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Entity.Repositorio
{
    public class AmigoRepositorio : IAmigoRepositorio
    {
        private string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GerenciadorAmigoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Domain.Amigo> PegarTodosDB()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAllAmigo";

                return connection.Query<Domain.Amigo>(sql, commandType: System.Data.CommandType.StoredProcedure).AsList();
            }

        }

        public Domain.Amigo GetAmigoDB(int idAmigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAmigoById";

                return connection.QueryFirst<Domain.Amigo>(sql, new { IdAmigo = idAmigo }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Domain.Amigo> GetAmigoNomeDB(string nome)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.SelectAmigoByName";

                return connection.Query<Domain.Amigo>(sql, new { NomeAmigo = nome }, commandType: System.Data.CommandType.StoredProcedure).AsList();
            }

        }

        public void DeletarDB(int idAmigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.DeleteAmigo";

                connection.Execute(sql, new { IdAmigo = idAmigo }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void CadastrarDB(Domain.Amigo amigo)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.InsertAmigo";

                connection.Execute(sql, new { Nome = amigo.Nome, Sobrenome = amigo.Sobrenome, DataNascimento = amigo.DataNascimento }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void AtualizarDB(Domain.Amigo amigo, int idAmigo)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.UpdateAmigo";

                connection.Execute(sql, new { Nome = amigo.Nome, Sobrenome = amigo.Sobrenome, DataNascimento = amigo.DataNascimento, IdAmigo = idAmigo }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Domain.Amigo> AniversariantesDoDiaDB()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "dbo.AniversarianteDoDia";

                return connection.Query<Domain.Amigo>(sql, commandType: System.Data.CommandType.StoredProcedure).AsList();
            }
        }
    }
}
