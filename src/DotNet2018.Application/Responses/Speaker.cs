using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet2018.Application.Responses
{
    public class Speaker
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Speaker() { }
        private Speaker(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }        

        public static Speaker Create(string name, string description)
        {
            return new Speaker(name, description);
        }        
    }
}
