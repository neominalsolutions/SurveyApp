using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Concretes
{
    public class Option
    {
        public string Name { get; private set; }

        public Option(string name)
        {
            Name = name;
        }

    }
}
