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
    public partial class study_Number : ContentPage
    {
        public ObservableCollection<Word> Words { get; set; } = new ObservableCollection<Word>();
        public study_Number()
        {
            InitializeComponent();
            for (int i = 35; i < 45; i++)
                Words.Add(Connect_Database.GetWord()[i]);
            CV.CurrentItemChanged += OnCurrentItemChanged;

            BindingContext = this;
        }

        private void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            Word word = Words[CV.Position];
            try
            {
                Connect_Database.InsertStudied(new Studied() { USERNAME = MainPage.Current_User.USERNAME, MATU = word.MATU });
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
            Stream audioStream = GetStreamFromFile(CV.Position.ToString() + ".wav");
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
            player.Play();
        }
        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("English4Kids.sound.Number." + filename);

            return stream;
        }
    }
}