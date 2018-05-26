using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DbDataLibrary.Models;

namespace SCI_lab6.ViewModels
{
    public class TourViewModel
    {
        
        public int Id { get; set; }

        public int? TourKindId { get; set; }
        public string TourKind { get; set; }

        public int? ClientId { get; set; }
        public string Client { get; set; }
        
        public string Name { get; set; }
        
        public double Price { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
