using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Interfaces
{
    interface IConfig
    {

        ISQLitePlatform Platfor { get; set; }
    }
}
