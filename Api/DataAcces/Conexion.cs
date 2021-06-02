using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Api.DataAcces
{
    public class Conexion
    {
        public static string StringConexion()
        {
            string Conexion;

            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            try
            {

                var configuration = builder.Build();

                Conexion = "Server=" + configuration["ServidorBDA"] +
                            "; Database=" + configuration["BaseDatos"] +
                            "; User id=" + configuration["Usuario"] +
                            "; Password=" + configuration["Pass"] + ";";

                return Conexion;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally 
            {

            }


        }
    }
}
