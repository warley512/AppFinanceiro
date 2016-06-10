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
using System.IO;
using SQLite;
using AppFinanceiro.BD;

namespace AppFinanceiro {

    [Activity(Label = "Resumo de lançamentos", Icon = "@drawable/logo")]
    class ResumoLancamentos : Activity {

        List<string> Dados;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ResumoLancamentos);

            var db = new SQLiteConnection(
                Path.Combine(
                    System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.MyDocuments), "DB_Financeiro"
                    )
                );

            List<BD_Lancamento> Dados = db.Table<BD_Lancamento>().ToList();
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 1,
                data="09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 0,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 2,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = -15.25,
                tipo = 2,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 0,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 0,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria do José de Abreu do bairro Nacional",
                valor = 15.25,
                tipo = 1,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 1,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 1,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 1,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 1525.00,
                tipo = 0,
                data = "09/06/2016"
            });
            Dados.Add(new BD_Lancamento {
                nome = "Padaria",
                valor = 15.25,
                tipo = 0,
                data = "09/06/2016"
            });

            Lista_ResumoLancamentos gl = new Lista_ResumoLancamentos(Dados, this);
            
            ListView list = FindViewById<ListView>(Resource.Id.lista_lancamentos);
            db.Close();
            list.Adapter = gl;
        }
    }
}