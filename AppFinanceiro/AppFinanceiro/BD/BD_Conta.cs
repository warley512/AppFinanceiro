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
    public class BD_Conta {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nome { get; set; }

        //Foreign keys
        public int id_usuario { get; set; }

    }
}