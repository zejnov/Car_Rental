using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.BusinessLayer.Dtos
{
    public class SaleDto
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
        /// Wartość procentowego discountu
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

            var sale = obj as SaleDto;

            bool equal = true;
            equal &= sale.Id == Id;
            equal &= sale.AmmountPercentage == AmmountPercentage;
            equal &= sale.Name == Name;

            return equal;
        }
    }
}
