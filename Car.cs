using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskadonet4
{
    internal class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int StNumber { get; set; }
        public override string ToString()
        {
            return $"{StNumber}: {Mark} - {Model} ({Year})";
        }
    }
}
