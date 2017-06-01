using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.DataLayer.Models
{
    public class CarType
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Marka pojazdu
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// Model pojazdu
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// koszt za dzień wyporzyczenia
        /// </summary>
        public int PricePerDay { get; set; }

        /// <summary>
        /// Sprawdza czy obiekty są równe
        /// </summary>
        /// <param name="obj">Model</param>
        /// <returns>IsEqual</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var carType = obj as CarType;

            bool isEqual = true;
            isEqual &= Id == carType.Id;
            isEqual &= Mark == carType.Mark;
            isEqual &= Model == carType.Model;
            isEqual &= PricePerDay == carType.PricePerDay;

            return isEqual;
        }
    }
}
