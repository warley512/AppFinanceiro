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
using AppFinanceiro.BD;
using Android.Graphics;

namespace AppFinanceiro
{
    class Lista_ResumoLancamentos: BaseAdapter<String>
    {
        List<BD_Lancamento> Dados;
        Activity C;

        public Lista_ResumoLancamentos(List<BD_Lancamento> dd, Activity act)
        {
            Dados = dd;
            C = act;
        }

        public override string this[int position]
        {
            get
            {
                return Dados[position].nome;
            }
        }

        public override int Count
        {
            get
            {
                return Dados.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            int img;
            Color cor;
            string dinheiro="R$";
            if (view == null)
            {
                view = C.LayoutInflater.Inflate(Resource.Layout.CelulaLancamento, null);
            }
            if (Dados[position].tipo == 0) { //Se for crédito
                img = Resource.Drawable.credito;
                cor = Color.Green;
            }
            else if (Dados[position].tipo == 1) { //Se for débito
                img = Resource.Drawable.debito;
                cor = Color.Red;
                dinheiro = "-R$";
            }
            else { //Se for transferencia
                img = Resource.Drawable.transferencia;
                cor = Color.Yellow;
                if (Dados[position].valor < 0) {
                    dinheiro = "-R$";
                    Dados[position].valor *= -1;
                }
            }

            view.FindViewById<ImageView>(Resource.Id.iconOperacao).SetImageResource(img);

            view.FindViewById<TextView>(Resource.Id.nomeOperacao).Text = Dados[position].nome;

            view.FindViewById<TextView>(Resource.Id.dataOperacao).Text = Dados[position].data+" as "+Dados[position].hora+" horas";

            view.FindViewById<TextView>(Resource.Id.valorOperacao).Text = dinheiro+Dados[position].valor.ToString();

            view.FindViewById<TextView>(Resource.Id.valorOperacao).SetTextColor(cor);

            view.FindViewById<TextView>(Resource.Id.categoriaOperacao).Text = "Teste";
            return view;
        }
    }
}
