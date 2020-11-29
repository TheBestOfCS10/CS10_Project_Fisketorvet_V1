using CS10_Project_Fisketorvet_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS10_Project_Fisketorvet_V1.Interfaces
{
    public interface IStores
    {
        Dictionary<int, Store> AllStores();
        Dictionary<int, Store> FilterStores(string criteria);
    }
}
