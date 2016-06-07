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

namespace AppFinanceiro.BD {
    class BD_Conta {
        [PrimaryKey, AutoIncrement]
        int id { get; set; }
        string nome { get; set; }

        //Foreign keys
        int id_usuario { get; set; }

    }
}