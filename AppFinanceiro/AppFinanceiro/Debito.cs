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
using AppFinanceiro.BD;

namespace AppFinanceiro
{
    [Activity(Label = "Lançamento")]
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

            //Conexão com o banco
            var db = new SQLiteConnection(Path.Combine(
               System.Environment.GetFolderPath(
                   System.Environment.SpecialFolder.MyDocuments), "DB_Financeiro"
               )
           );

            //Cria lista de categorias
            List<BD_Usuario> DadosUser = db.Table<BD_Usuario>().ToList();
            List<String> listCategorias = new List<string>();

            //passa lista de categorias para string
            for (int i = 0; i < DadosUser.Count; i++)
            {
                listCategorias.Add(DadosUser[i].nome);
            }

            //Crédito ou débito
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);

            //Categoria
            Spinner spinnerCategoria = FindViewById<Spinner>(Resource.Id.spinnerCategoria);

            //Crédito ou débito
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                     this, Resource.Array.account_types, Android.Resource.Layout.SimpleSpinnerItem);


            //Adapter de categorias
            var adapterCategorias = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, listCategorias);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //Categoria
            adapterCategorias.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            
            //Débito ou crédito
            spinner.Adapter = adapter;

            //Categoria
            spinnerCategoria.Adapter = adapterCategorias;


        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
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