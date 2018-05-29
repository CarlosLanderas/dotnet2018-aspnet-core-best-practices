using DotNet2018.Application.Responses;
using System.Collections.Generic;

namespace DotNet2018.Application.Services
{
    public class Speakers
    {
        public static List<Speaker> Collection = new List<Speaker>()
        {
            Speaker.Create("Scott Hunter","Director of Program Management at Microsoft" ),
            Speaker.Create("César de la Torre","Sr. Program Manager (.NET Product Group) at Microsoft" ),            
            Speaker.Create("Diego Vega", "Principal Program Manager at Microsoft" ),
            Speaker.Create("James Montemagno", "Principal Program Manager at Microsoft, Mobile Developer Tools" ),
            Speaker.Create("Remo H Hansen", "MVP Typescript"),
            Speaker.Create("Olga Martí", "MVP Office and Servers"),
            Speaker.Create("Unai Zorrilla", "MVP Visual Studio Development Technologies"),
            Speaker.Create("Luis Ruiz Pavón", "MVP Visual Studio Development Technologies"),
            Speaker.Create("Carlos Landeras", "MVP Visual Studio Development Technologies"),
            Speaker.Create("Eduard Tomás", "MVP Visual Studio Development Technologies")
        };
    }
}
