using System;

namespace BinaryMash.PactDemo.Provider.Model
{
    public class Version 
    {
        public string Build { get; set; }

        public DateTime Date { get; set; }

        //MOD-1 - provider returns a new parameter
        //public string Branch { get; set; }
    }
}
