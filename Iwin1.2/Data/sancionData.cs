using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iwin1._2.Domain;

namespace Iwin1_2.Data
{
    public class sancionData
    {

        string connectionString = "Server=163.178.107.130; Database=iwincjm; Uid= laboratorios; Pwd=UCRSA.118;";

        public sancionData()
        {
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }


        public List<sancionColectiva> GetAllSancionescolectivas()
        {
            sancionColectiva sancionColectiva;
            List<sancionColectiva> jugadorList = new List<sancionColectiva>();
            using (MySqlConnection sqlCon = GetConnection())
            {

                sqlCon.Open();
                String query = "select * from sancionColectiva;";

                MySqlCommand sqlSelect = new MySqlCommand(query, sqlCon);

                using (MySqlDataReader reader = sqlSelect.ExecuteReader())
                {


                    while (reader.Read())
                    {
                        sancionColectiva = new sancionColectiva();
                        sancionColectiva.Identificador= reader.GetInt16("identificador");
                        sancionColectiva.Tipo= reader.GetString("tipo");
                        sancionColectiva.Motivo = reader.GetString("motivo");

                        sancionColectiva.Equipo = informacionEquipo(reader.GetInt32("identificador_equipo"));

                        jugadorList.Add(sancionColectiva);

                    }
                    sqlCon.Close();

                }
            }
            return jugadorList;





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



    }
}
