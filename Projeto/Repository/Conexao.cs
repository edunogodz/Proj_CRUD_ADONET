using System;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace Projeto.Repository
{
    public class Conexao
    {
        protected SqlConnection Con;

        protected SqlCommand Cmd;

        protected SqlDataReader Dr;

        //Método para abrir a conexão com o SqlServer:
        protected void AbrirConexao()
        {
            try
            {
                Con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookListRazor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                //< add name = "DatabaseCrud" connectionString = "Data Source=(localdb)MSSQLLocalDB; Initial Catalog=BookListRazor; Integrated Security=True; MultipleActiveResultSets=True;"
                //providerName = "System.Data.SqlClient" />
                //< add name = "DefaultConnection" connectionString = "Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=BookListRazor; Integrated Security=True; MultipleActiveResultSets=True;" />   
                //< add name = "PodioAspnetSampleDb" connectionString = "server=(localdb)\MSSQLLocalDB;database=BookListRazor; Integrated Security=True; MultipleActiveResultSets=True" providerName = "System.Data.SqlClient" />

                //Outra maneira de criar uma connection string (usando o Web.Config
                //Con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjetoCRUD"].ConnectionString);
                Con.Open();
            }
            catch (Exception e)
            {
                // Caso dê algum problema, enviar uma mensagem informando o erro:
                throw new Exception("Erro ao abrir a conexão: " + e.Message);
            }
        }

        //Método para fechar a conexão:
        protected void FecharConexao()
        {
            try
            {
                if (Con != null)
                {
                    Con.Close();
                }
            }
            catch (Exception e)
            {
                // Caso dê algum problema, enviar uma mensagem informando o erro:
                throw new Exception("Erro ao fechar a conexão: " + e.Message);
            }
        }
    }
}
