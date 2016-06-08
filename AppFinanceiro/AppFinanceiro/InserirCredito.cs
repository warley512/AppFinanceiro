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
    [Activity(Label = "InserirCredito")]

    public class InserirCredito : Activity {

        protected override void OnCreate (Bundle bundle) {
            base.OnCreate(bundle);
            //SetContentView(Resource.Layout.Credito);
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        double valor = 0;
        string descricao = "";
        string tipoDeConta = "";

        /*public InserirCredito(double valor, string descricao, string tipoDeConta) {
            this.valor = valor;
            this.descricao = descricao;
            this.tipoDeConta = tipoDeConta;
        }*/



        }
    }