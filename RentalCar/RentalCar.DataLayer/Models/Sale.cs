using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataLayer.Models
{
    /// <summary>
    /// Model reprezentujący  promocję
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa promocji
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Wartość procentowego rabatu
        /// </summary>
        public int AmmountPercentage { get; set; }

        /// <summary>
        /// Sprawdza czy obj jest równe mi
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var sale = obj as Sale;

            bool equal = true;
            equal &= sale.Id == Id;
            equal &= sale.AmmountPercentage == AmmountPercentage;
            equal &= sale.Name == Name;

            return equal;
        }
    }
}
