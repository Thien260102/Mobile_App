using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace English4Kids
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class study_ABC : ContentPage
    {
        public ObservableCollection<Word_Edit> Words { get; set; } = new ObservableCollection<Word_Edit>();

        public study_ABC()
        {
            InitializeComponent();
            for (int i = 0; i < 26; i++)
                Words.Add(Connect_Database.GetWord()[i].ConvertToWordEdit());
            CV.CurrentItemChanged += OnCurrentItemChanged;
            
            BindingContext = this;
            
        }

        //them vo studied
        private void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            int i = CV.Position;
            int MaTu = Connect_Database.GetWord()[i].MATU;
            try
            {
                Connect_Database.InsertStudied(new Studied() { USERNAME = MainPage.Current_User.USERNAME, MATU = MaTu });
            }
            catch
            {

            }
        }
        private void btn_back_clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new study();
            
        }
        private void btn_volume_clicked(object sender, EventArgs e)
        {
            Word_Edit word = Words[CV.Position];


            Stream audioStream = GetStreamFromFile(word.ChuDauTien + ".wav");
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
            player.Play();
        }
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            
            var stream = assembly.GetManifestResourceStream("English4Kids.sound.ABC." + filename);

            return stream;
        }

    }
}