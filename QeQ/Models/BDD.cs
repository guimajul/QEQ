using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QeQ.Models
{
    public static class BDD
    {
        private static string conexionString = "Server=10.128.8.16;Database=QEQC08;User ID=QEQC08;pwd=QEQC08;";
        private static SqlConnection Conectar()
        {
            SqlConnection conector = new SqlConnection(conexionString);
            conector.Open();
            return conector;
        }
        private static void Desconectar(SqlConnection conector)
        {
            conector.Close();
        }


        public static Usuario ExisteUsuario(string EMail, string Contraseña)
        {

            //string Devuelve = "";
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "ExisteUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Mail", EMail);
            Consulta.Parameters.AddWithValue("@Contraseña", Contraseña);


            var dataReader = Consulta.ExecuteReader();
            Usuario User = new Usuario();
            if (dataReader.Read())
            {
                User.EMail = dataReader["Mail"].ToString();

                User.NomUs = dataReader["NombreDeUsuario"].ToString();
                User.Contraseña = dataReader["Contraseña"].ToString();
                User.adm = Convert.ToBoolean(dataReader["Administrador"]);
            }
            Desconectar(Conexión);
            return User;
        }

        public static bool CrearUsuario(string EMail, string Contraseña, string NombreDeUsuario)
        {
            bool a = false;
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "CrearUsuario";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Mail", EMail);
            Consulta.Parameters.AddWithValue("@Contraseña", Contraseña);
            Consulta.Parameters.AddWithValue("@NombreDeUsuario", NombreDeUsuario);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static List<Categoria> ListarCategorias()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "TraerCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {

                int id = Convert.ToInt32(dataReader["IdCategoria"]);
                string NomCat = dataReader["Categoria"].ToString();


                Categoria categ = new Categoria(id, NomCat);
                ListaCategorias.Add(categ);


            }
            Desconectar(conexion);
            return ListaCategorias;

        }




        public static string VerCategoria(int IdCategoria)
        {
            string Cat = "";


            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "VerCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@pIdCategoria", IdCategoria);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            if (DataReader.Read())
            {
                int IdCat = Convert.ToInt32(DataReader["IdCategoria"]);
                Cat = DataReader["Categoria"].ToString();
            }
            Desconectar(Conexión);
            return Cat;
        }


        public static bool CrearCategoria(string Categoria)
        {
            bool a = false;
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "CrearCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Categoria", Categoria);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }




        public static bool EliminarCategoria(int IdCategoria)
        {
            bool a = false;
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "EliminarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
            if (regsAfectados == 0)
            {
                a = false;
            }
            return a;
        }
    }
}