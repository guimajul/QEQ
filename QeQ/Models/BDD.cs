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

        //-------------------------------------------------------------------------------------------------------------
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




      

        public static Categoria TraerCategoria(int IdCategoria)
        {
            Categoria Cat = new Categoria();

            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "VerCategorias";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            if (DataReader.Read())
            {
                Cat.IdCategoria = Convert.ToInt32(DataReader["IdCategoria"]);
                Cat.cat = DataReader["Categoria"].ToString();
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

        public static void ModificarCategoria(int IdCategoria ,string categoria)
        {
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "ModificarCategoria";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            Consulta.Parameters.AddWithValue("@Categoria", categoria);
            Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
        }

        //---------------------------------------------------------------------------------------------------------

        public static List<Personajes> ListarPersonajes()
        {
            
            List<Personajes> ListaPersonajes = new List<Personajes>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "TraerPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Personajes Perso = new Personajes();
                Perso.idPerso = Convert.ToInt32(dataReader["idPersonaje"]);
                Perso.Nom = dataReader["Nombre"].ToString();
                Perso.Cat = Convert.ToInt32(dataReader["Categoria"]);
                ListaPersonajes.Add(Perso);


            }
            Desconectar(conexion);
            return ListaPersonajes;

        }

        public static bool CrearPersonaje(string nombre, int idcateg )
        {
            bool a = false;
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "CrearPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@Nombre", nombre);
            Consulta.Parameters.AddWithValue("@Categoria", idcateg);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }



        public static bool EliminarPersonaje(int IdPerso)
        {
            bool a = false;
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "EliminarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IdPersonaje", IdPerso);
            int regsAfectados = Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
            if (regsAfectados == 0)
            {
                a = false;
            }
            return a;
        }

        public static Personajes TraerPersonajes(int idPerso)
        {
            Personajes Perso = new Personajes();

            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "sp_Verpersonajes";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IdPersonaje", idPerso);
            SqlDataReader DataReader = Consulta.ExecuteReader();
            if (DataReader.Read())
            {


                //IdPersonaje = idPerso;
                //Nombre = Nom;
                //Categoria = Cat;

                
                Perso.idPerso = Convert.ToInt32(DataReader["idPersonaje"]);
                Perso.Nom = DataReader["Nombre"].ToString();
                Perso.Cat = Convert.ToInt32(DataReader["Categoria"]);
            }
            Desconectar(Conexión);
            return Perso;
        }

        public static void ModificarPersonaje(int IdPersonaje, string Nombre, int Categoria)
        {
            SqlConnection Conexión = Conectar();
            SqlCommand Consulta = Conexión.CreateCommand();
            Consulta.CommandText = "ModificarPersonaje";
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.Parameters.AddWithValue("@IdPersonaje", IdPersonaje);
            Consulta.Parameters.AddWithValue("@Nombre", Nombre);
            Consulta.Parameters.AddWithValue("@Categoria", Categoria);
            Consulta.ExecuteNonQuery();
            Desconectar(Conexión);
        }





        //------------------------------------------------------------------------------------------------------

        public static List<Caracteristicas> ListarPreguntas()
        {

            List<Caracteristicas> ListaPreguntas = new List<Caracteristicas>();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "TraerCaracteristicas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                Caracteristicas carac = new Caracteristicas();
                carac.IdCaracteristica = Convert.ToInt32(dataReader["IdCaracteristica"]);
                carac.Caracteristica = dataReader["Caracteristica"].ToString();
                carac.Pregunta = dataReader["Pregunta"].ToString();
                
                ListaPreguntas.Add(carac);


            }
            Desconectar(conexion);
            return ListaPreguntas;

        }
    }
}