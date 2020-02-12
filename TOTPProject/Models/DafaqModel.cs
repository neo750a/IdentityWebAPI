using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOTPProject.Models
{
    public class DafaqModel
    {
        public bool totpTestOne { get; set; }
        public bool totpTestTwo { get; set; }
        public string codeOne { get; set; }
        public string codeTwo { get; set; }
        public long timesCodeOneBeenVerified { get; set; }
        public long timesCodeTwoBeenVerified { get; set; }
    }
}
