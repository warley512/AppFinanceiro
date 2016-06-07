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
    class GerenciaMenu: BaseAdapter<String>
    {
        List<String> Dados;
        Activity C;

        public GerenciaMenu(List<String> dd, Activity act)
        {
            Dados = dd;
            C = act;
        }

        public override string this[int position]
        {
            get
            {
                return Dados[position];
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
            if (view == null)
            {
                view = C.LayoutInflater.Inflate(Resource.Layout.Celula, null);
            }

            view.FindViewById<ImageView>(Resource.Id.imagemItem).SetImageResource(Resource.Drawable.carro);

            view.FindViewById<TextView>(Resource.Id.textLabel).Text = Dados[position];

            return view;
        }
    }
}
