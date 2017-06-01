using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.BusinessLayer.Dtos
{    
    public class CarTypeDto
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
        /// 
        /// </summary>
        /// <param name="obj">Model</param>
        /// <returns>IsEqual</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var carTypeDto = obj as CarTypeDto;

            bool isEqual = true;
            isEqual &= Id == carTypeDto.Id;
            isEqual &= Mark == carTypeDto.Mark;
            isEqual &= Model == carTypeDto.Model;
            isEqual &= PricePerDay == carTypeDto.PricePerDay;

            return isEqual;
        }

    }
}
