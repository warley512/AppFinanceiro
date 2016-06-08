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

namespace AppFinanceiro
{
    [Activity(Label = "AppFinanceiro")]
    public class Debito : Activity
    {
        public double valor { get; set; }
        public string descricao { get; set; }
        public string tipoConta { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Debito);

            FindViewById<EditText>(Resource.Id.valorDebito).Click += valorDebitoFocus;
        }

        public void valorDebitoFocus(object sender, EventArgs e)
        {
            FindViewById<EditText>(Resource.Id.valorDebito).Text = "";
        }

        /*
        public Debito(double valor, string descricao, string tipoConta)
        {
            this.valor = valor;
            this.descricao = descricao;
            this.tipoConta = tipoConta;

        }
        */




    }
}