﻿using System;
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

    }
}
