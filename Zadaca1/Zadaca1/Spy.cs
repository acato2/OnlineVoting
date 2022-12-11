using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Spy : IProvjera
{
    public bool Glasao { get; set; }
    public bool DaLiJeVecGlasao(string IDBroj)
    {
        return Glasao;
    }
}

