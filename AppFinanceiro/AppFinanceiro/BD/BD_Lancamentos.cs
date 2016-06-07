using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;
using System.IO;

namespace AppFinanceiro {
    class BD_Lancamentos {
        [PrimaryKey, AutoIncrement]
        int id { get; set; }

        string nome { get; set; }
        int tipo { get; set; }
        double valor { get; set; }
        string comentario { get; set; }
        string data { get; set;}
        int hora { get; set; }

        //Foreign keys
        int id_conta { get; set; }
    }
}