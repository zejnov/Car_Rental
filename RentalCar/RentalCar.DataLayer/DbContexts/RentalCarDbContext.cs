using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCar.DataLayer.Models;

namespace RentalCar.DataLayer.DbContexts
{
    /// <summary>
    /// Klasa modelująca bazę danych
    /// </summary>
    public class RentalCarDbContext : DbContext
    {
        /// <summary>
        /// Podstawowy konstruktor
        /// </summary>
        public RentalCarDbContext() : base(GetConnectionString()) { }

        /// <summary>
        /// Zwraca tabelę CarType
        /// </summary>
        public DbSet<CarType> CarTypesDbSet {get; set; }

        /// <summary>
        /// Pobiera conection stringa
        /// </summary>
        /// <returns>Obiekt typu string, który jest connectionString</returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RentalCarSql"].ConnectionString;
        }
    }
}
