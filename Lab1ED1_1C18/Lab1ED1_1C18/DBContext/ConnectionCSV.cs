using Lab1ED1_1C18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1ED1_1C18.DBContext
{
    public class ConnectionCSV
    {
        private static volatile ConnectionCSV Instance;
        private static object syncRoot = new Object();

        public List<Jugador> Jugadores = new List<Jugador>();

        public int IDActual { get; set; }

        private ConnectionCSV()
        {
            IDActual = 0;
        }

        public static ConnectionCSV getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new ConnectionCSV();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}