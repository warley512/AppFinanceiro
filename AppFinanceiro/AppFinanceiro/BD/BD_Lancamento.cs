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
    public class BD_Lancamento {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string nome { get; set; }
        public int tipo { get; set; } //0 para crédito, 1 para débito, 2 para transferencia
        public double valor { get; set; }
        public string comentario { get; set; }
        public string data { get; set;}
        public int hora { get; set; }

        //Foreign keys
        public int id_conta { get; set; }
    }
}