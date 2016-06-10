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
    [Activity(Label = "Lan�amento", Icon = "@drawable/logo")]
    public class Debito : Activity
    {
        public double valor { get; set; }
        public string descricao { get; set; }
        public string tipoConta { get; set; }
        TextView _dateDisplay;
        Button _dateSelectButton;

        private TextView time_display;
        private Button pick_button;

        private int hour;
        private int minute;

        const int TIME_DIALOG_ID = 0;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Debito);

            FindViewById<EditText>(Resource.Id.valorDebito).Click += valorDebitoFocus;

            //Conex�o com o banco
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

            //Cr�dito ou d�bito
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerDebitoTipoLanc);

            //Categoria
            Spinner spinnerCategoria = FindViewById<Spinner>(Resource.Id.spinnerCategoria);

            //Cr�dito ou d�bito
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                     this, Resource.Array.account_types, Android.Resource.Layout.SimpleSpinnerItem);


            //Adapter de categorias
            var adapterCategorias = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, listCategorias);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //Categoria
            adapterCategorias.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            
            //D�bito ou cr�dito
            spinner.Adapter = adapter;

            //Categoria
            spinnerCategoria.Adapter = adapterCategorias;

            //implementa��o hora e data
           // _dateDisplay = FindViewById<TextView>(Resource.Id.date_display);
            _dateSelectButton = FindViewById<Button>(Resource.Id.date_select_button);
            _dateSelectButton.Click += DateSelect_OnClick;

            //implementa��o hora
            // Capture our View elements
            time_display = FindViewById<TextView>(Resource.Id.timeDisplay);
            pick_button = FindViewById<Button>(Resource.Id.pickTime);

            // Add a click listener to the button
            pick_button.Click += (o, e) => ShowDialog(TIME_DIALOG_ID);

            // Get the current time
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;

            // Display the current date
            UpdateDisplay();



        }

        protected override Dialog OnCreateDialog(int id)
        {
            if (id == TIME_DIALOG_ID)
                return new TimePickerDialog(this, TimePickerCallback, hour, minute, false);

            return null;
        }

        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            string time = string.Format("{0}:{1}", hour, minute.ToString().PadLeft(2, '0'));
            time_display.Text = time;
        }

        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DataHora frag = DataHora.NewInstance(delegate (DateTime time)
            {
                //_dateDisplay.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DataHora.TAG);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

   //         string toast = string.Format("voc� selecionou: {0}", spinner.GetItemAtPosition(e.Position));
   //         Toast.MakeText(this, toast, ToastLength.Long).Show();
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