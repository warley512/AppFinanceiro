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


namespace AppFinanceiro.BD
{
    class BD_Lancamento_Categoria
    {
        [PrimaryKey, AutoIncrement]
        int id { get; set; }
        int id_lancamento { get; set; }
        int id_categoria { get; set; }
     
    }
}