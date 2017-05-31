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
        /// Marka pojazdu
        /// </summary>
        public string Mark;

        /// <summary>
        /// 
        /// </summary>
        public string Model;
        public int PricePerDay;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        public void cos(int x)
        {
           var  Mark = new CarTypeDto();
        }
    }
}
