// Models/Cliente.cs
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class Cliente
{
    public int ID_Cliente { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }

    public void AddCliente()
    {
        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO Cliente (Nome, Endereco, Telefone, RG, CPF, Email) VALUES (@Nome, @Endereco, @Telefone, @RG, @CPF, @Email)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Endereco", Endereco);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@RG", RG);
            cmd.Parameters.AddWithValue("@CPF", CPF);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.ExecuteNonQuery();
            ID_Cliente = (int)cmd.LastInsertedId;
        }
    }

    public static List<Cliente> GetClientes()
    {
        List<Cliente> clientes = new List<Cliente>();

        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM Cliente";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var cliente = new Cliente
                {
                    ID_Cliente = reader.GetInt32("ID_Cliente"),
                    Nome = reader.GetString("Nome"),
                    Endereco = reader.GetString("Endereco"),
                    Telefone = reader.GetString("Telefone"),
                    RG = reader.GetString("RG"),
                    CPF = reader.GetString("CPF"),
                    Email = reader.GetString("Email")
                };
                clientes.Add(cliente);
            }
        }

        return clientes;
    }

    public void UpdateCliente()
    {
        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "UPDATE Cliente SET Nome = @Nome, Endereco = @Endereco, Telefone = @Telefone, RG = @RG, CPF = @CPF, Email = @Email WHERE ID_Cliente = @ID_Cliente";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Nome", Nome);
            cmd.Parameters.AddWithValue("@Endereco", Endereco);
            cmd.Parameters.AddWithValue("@Telefone", Telefone);
            cmd.Parameters.AddWithValue("@RG", RG);
            cmd.Parameters.AddWithValue("@CPF", CPF);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@ID_Cliente", ID_Cliente);
            cmd.ExecuteNonQuery();
        }
    }

    public static void DeleteCliente(int id)
    {
        using (var connection = BancodeDados.GetConnection())
        {
            connection.Open();
            string query = "DELETE FROM Cliente WHERE ID_Cliente = @ID_Cliente";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ID_Cliente", id);
            cmd.ExecuteNonQuery();
        }
    }
}
