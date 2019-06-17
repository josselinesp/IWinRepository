using Iwin1._2.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iwin1_2.Data
{
    public class AnotacionData
    {



        string connectionString = "Server=163.178.107.130; Database=iwincjm; Uid= laboratorios; Pwd=UCRSA.118;";

        public AnotacionData()
        {
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }


        public List<anotacion> GetAllAnotaciones(int idEquipo,int idJuego)
        {
            anotacion anotacion;
            List<anotacion> anotacionList = new List<anotacion>();
            using (MySqlConnection sqlCon = GetConnection())
            {

                sqlCon.Open();
                String query = "select * ,sum(cantidad_goles) as cantidad from anotaciones where  identificador_juego= " + idJuego + " group by identificador_jugador order By cantidad desc ";

                MySqlCommand sqlSelect = new MySqlCommand(query, sqlCon);

                using (MySqlDataReader reader = sqlSelect.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        anotacion = new anotacion();
                        anotacion.Identificador = reader.GetInt16("identificador");
                        anotacion.CantidadGoles = reader.GetInt32("cantidad");
                        anotacion.Juego = reader.GetInt32("identificador_juego");
                        anotacion.Jugador = getJugador(reader.GetString("identificador_jugador"));
                        anotacion.Equipo = informacionEquipo(reader.GetInt32("identificador_equipo"));

                        anotacionList.Add(anotacion);
                    }
                    sqlCon.Close();

                }
            }
            return anotacionList;





        }


        public List<anotacion> GetAllAnotacionesByCampeonato(int id)
        {
            anotacion anotacion;
            List<anotacion> anotacionList = new List<anotacion>();
            using (MySqlConnection sqlCon = GetConnection())
            {

                sqlCon.Open();
                String query = "select * ,sum(cantidad_goles) as cantidad from anotaciones join Juego j on j.identificador=identificador_juego join campeonato c on c.identificador=j.identificador_campeonato  where c.identificador = " + id + "  group by identificador_jugador order By cantidad desc ";

                MySqlCommand sqlSelect = new MySqlCommand(query, sqlCon);

                using (MySqlDataReader reader = sqlSelect.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        anotacion = new anotacion();
                        anotacion.Identificador = reader.GetInt16("identificador");
                        anotacion.CantidadGoles = reader.GetInt32("cantidad");
                        anotacion.Juego = reader.GetInt32("identificador_juego");
                        anotacion.Jugador = getJugador(reader.GetString("identificador_jugador"));
                        anotacion.Equipo = informacionEquipo(reader.GetInt32("identificador_equipo"));

                        anotacionList.Add(anotacion);
                    }
                    sqlCon.Close();

                }
            }
            return anotacionList;





        }






        public List<anotacion> GetAllSancionesIndividuales(int idEquipo, int idJugador)
        {
            anotacion anotacion;
            List<anotacion> anotacionList = new List<anotacion>();
            using (MySqlConnection sqlCon = GetConnection())
            {
                String query;
                sqlCon.Open();
                if (idJugador == -1)
                {
                    query = "select * from anotacion where identificadorEquipo = " + idEquipo;



                }
                else
                {
                    query = "select * from anotacion where identificadorEquipo = " + idEquipo + " and identificador_jugador = '" + idJugador + "'";
                }

                MySqlCommand sqlSelect = new MySqlCommand(query, sqlCon);

                using (MySqlDataReader reader = sqlSelect.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        anotacion = new anotacion();
                        anotacion.Identificador = reader.GetInt16("identificador");
                        anotacion.CantidadGoles = reader.GetInt32("cantidad_goles");
                        anotacion.Juego = reader.GetInt32("identificador_juego");
                        anotacion.Jugador = getJugador(reader.GetString("identificador_jugador"));
                        anotacion.Equipo = informacionEquipo(reader.GetInt32("identificador_equipo"));

                        anotacionList.Add(anotacion);
                    }
                    sqlCon.Close();
                

                }
            }
            return anotacionList;





        }






        public Equipo informacionEquipo(int id)
        {

            Equipo equipo = new Equipo();

            string connectionString = "Server=163.178.107.130; Database=iwincjm; Uid= laboratorios; Pwd=UCRSA.118;";
            string query = "select * from equipo where identificador=" + id + "";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 70;
            MySqlDataReader reader;
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    equipo = new Equipo();
                    equipo.Identificador = reader.GetInt32("identificador");
                    equipo.NombreEquipo = reader.GetString("nombre_equipo");
                    equipo.Categoria = reader.GetString("categoria");
                    equipo.Rama = reader.GetString("rama");
                    equipo.CanchaSede = reader.GetString("cancha_sede");
                    equipo.TelefonoRepresentante = reader.GetString("telefono_representante");
                    equipo.NombreRepresentante = reader.GetString("nombre_representante");
                    equipo.ContraseniaEquipo = reader.GetString("contrasenia_equipo");



                }
            }
            else
            {
                Console.WriteLine("No se encontraron datos.");
            }

            databaseConnection.Close();
            Console.WriteLine(equipo.Categoria);
            return equipo;
        }



        





        public void registrarAnotacion(anotacion anotacion)
        {



            string connectionString = "Server=163.178.107.130; Database=iwincjm; Uid= laboratorios; Pwd=UCRSA.118;";
            // Tu consulta en SQL
            string query = "Insert into anotaciones values( null , null," + anotacion.Equipo.Identificador + ",'" + anotacion.Jugador.Identificacion + "'," + anotacion.Juego+  "," + anotacion.CantidadGoles + " ) ";


            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            // A consultar !

            // Abre la base de datos
            databaseConnection.Open();

            // Ejecuta la consultas
            reader = commandDatabase.ExecuteReader();

            // Hasta el momento todo bien, es decir datos obtenidos

            // IMPORTANTE :#
            // Si tu consulta retorna un resultado, usa el siguiente proceso para obtener datos



            // Cerrar la conexión
            databaseConnection.Close();


        }






        public Jugador getJugador(string identificacion)
        {

            Jugador jugador;
            List<Jugador> jugadorList = new List<Jugador>();
            string connectionString = "Server=163.178.107.130; Database=iwincjm; Uid= laboratorios; Pwd=UCRSA.118;";
            // Tu consulta en SQL
            string query = "SELECT * FROM Jugador where identificacion = '" + identificacion + "'";
            Console.Write(query);


            // Prepara la conexión
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            // A consultar !

            // Abre la base de datos
            databaseConnection.Open();

            // Ejecuta la consultas
            reader = commandDatabase.ExecuteReader();

            // Hasta el momento todo bien, es decir datos obtenidos

            // IMPORTANTE :#
            // Si tu consulta retorna un resultado, usa el siguiente proceso para obtener datos

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    jugador = new Jugador();
                    jugador.Identificacion = reader.GetString("identificacion");
                    jugador.Nombre = reader.GetString("nombre");
                    jugador.Apellidos = reader.GetString("apellidos");
                    jugador.FechaNacimiento = reader.GetDateTime("fecha_nacimiento");
                    jugador.IdEquipo = reader.GetInt32("identificador_equipo");

                    jugadorList.Add(jugador);
                }
            }
            else
            {

                Console.WriteLine("No se encontraron datos.");
            }

            // Cerrar la conexión
            databaseConnection.Close();


            if (jugadorList.Count() > 0) { return jugadorList[0]; }



            return new Jugador();
        }




    }






}
