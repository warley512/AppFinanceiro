using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace AppFinanceiro
{
    [Activity(Label = "AppFinanceiro", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Dados = new List<String>();

            Dados.Add("Cadastro de Contas");
            Dados.Add("Débito");
            Dados.Add("Crédito");
            Dados.Add("Resumo Financeiro");

            // Get our button from the layout resource,
            // and attach an event to it
            ListView list = FindViewById<ListView>(Resource.Id.listaDados);
            GerenciaLista gl = new GerenciaLista(Dados, this);

            list.Adapter = gl;
            list.ItemClick += List_ItemClick;


        }
        void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, Dados[e.Position], ToastLength.Short).Show();
        }
    }
}

