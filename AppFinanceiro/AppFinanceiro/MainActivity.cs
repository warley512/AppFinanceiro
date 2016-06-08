using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using System.Collections.Generic;
using AppFinanceiro.BD;

namespace AppFinanceiro
{
    [Activity(Label = "AppFinanceiro", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<String> Dados;
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Instancia banco de dados
            var db = new SQLiteConnection(Path.Combine(
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.MyDocuments), "DB_Financeiro"
                )
            );

            db.CreateTable<BD_Atributo>(); // Cria as colunas de acordo com o definido na classe Cliente
            db.CreateTable<BD_Categoria>();
            db.CreateTable<BD_Conta>();
            db.CreateTable<BD_Lancamento>();
            db.CreateTable<BD_Lancamento_Categoria>();
            db.CreateTable<BD_Usuario>();

            db.Insert(new BD_Usuario() { nome = "Cliente1" , email = "jo@as.com", senha="123abc"});

            // Get our button from the layout resource,
            // and attach an event to it
            ListView list = FindViewById<ListView>(Resource.Id.listaDados);
            GerenciaMenu gl = new GerenciaMenu(Dados, this);
            List<BD_Usuario> CLIS = db.Table<BD_Usuario>().ToList(); //Cria uma Lista com o que está na tabela Cliente transformado em lista.

            db.Close();


        }
    }
}

