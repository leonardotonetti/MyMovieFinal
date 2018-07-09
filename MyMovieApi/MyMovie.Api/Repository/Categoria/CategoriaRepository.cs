using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MyMovie.Api.Repository.Categoria
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IConfiguration _config;

        public CategoriaRepository(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Core.Categoria.Categoria> Get()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_config.GetConnectionString("MyMovie")))
                {
                    return db.Query<Core.Categoria.Categoria>("SELECT * FROM [dbo].[Categoria]").ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Core.Categoria.Categoria Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString("MyMovie")))
            {
                return db.Query<Core.Categoria.Categoria>($"SELECT * FROM [dbo].[Categoria] WHERE CategoriaId = {id}").SingleOrDefault();
            }
        }

        public void Post(Core.Categoria.Categoria categoria)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString("MyMovie")))
            {
                const string insertQuery = @"
                    INSERT INTO [dbo].[Categoria]([Nome], [CadastroUsuarioId], [DataCadastro], [Ativo]) 
                        VALUES (@Nome, @CadastroUsuarioId, @DataCadastro, @Ativo)";

                db.Execute(insertQuery, categoria);
            }
        }

        public void Put(Core.Categoria.Categoria categoria)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString("MyMovie")))
            {
                const string updateQuery = @"
                    UPDATE [dbo].[Categoria]
                        SET Nome                = @Nome,
                            AlteracaoUsuarioId  = @AlteracaoUsuarioId,
                            DataAlteracao       = @DataAlteracao,
                            Ativo               = @Ativo
                     WHERE CategoriaId = @CategoriaId";

                db.Execute(updateQuery, categoria);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString("MyMovie")))
            {
                var deleteQuery = $"DELETE FROM [dbo].[Categoria] WHERE CategoriaId = {id}";

                db.Execute(deleteQuery);
            }
        }
    }
}
