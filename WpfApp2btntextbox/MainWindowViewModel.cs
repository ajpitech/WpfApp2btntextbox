using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace WpfApp2btntextbox
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand TextBoxAddCommand { get; set; }
        private string Txtdata1 { get; set; }
        public string TxtData1
        {
            get { return Txtdata1; }
            set
            {
                Txtdata1 = value;
                AddLbl();
            }
        }
        public BaseViewModel ActiveView { get; set; }
        public string Lbldata { get; set; }
        public ObservableCollection<democlass> ListString { get; set; } = new ObservableCollection<democlass>();
        // public ObservableCollection<democlassString> ListString1 { get; set; } = new ObservableCollection<democlassString>(); 
        public MainWindowViewModel()
        {

            TextBoxAddCommand = new RelayCommand(TextBoxAddCommandClick);


        }

        public void AddLbl()
        {

            Lbldata = Txtdata1;
            for (int i = 0; i < ListString.Count; i++)
            {
                string s = ListString[i].txtdata;

                if (Lbldata == "")
                {
                    Lbldata += s;
                }
                else
                {
                    if (s != "")
                    {
                        Lbldata = Lbldata + ", " + s;
                    }
                    else
                    { 
                    Lbldata += s;

                    }
                }
            }
            OnPropertyChanged(nameof(Lbldata));

        }
        public void TextBoxMinusCommandClick(object obj)
        {
            int index = ListString.IndexOf((democlass)obj);

            ListString.RemoveAt(index);
            OnPropertyChanged(nameof(ListString));
            AddLbl();
        }

        public int count { get; set; } = 0;
        private void TextBoxAddCommandClick(object obj)
        {
            ListString.Add(new democlass(this) { txtNO = count = count + 1, txtdata = "" });

            OnPropertyChanged(nameof(ListString));

        }
    }
    public class democlass : BaseViewModel
    {
        private MainWindowViewModel mainWindowViewModel;

        public democlass(MainWindowViewModel mainWindowViewModel)
        {
            this.mainWindowViewModel = mainWindowViewModel;
            TextBoxMinusCommand = new RelayCommand(mainWindowViewModel.TextBoxMinusCommandClick);

        }

        private string txtData { get; set; }
        public string txtdata
        {
            get { return txtData; }
            set
            {
                txtData = value;
                if (mainWindowViewModel != null)
                {
                    mainWindowViewModel.AddLbl();
                }
            }
        }
        public int txtNO { get; set; }
    }
    //public class democlassString
    //{
    //    public string txtdata { get; set; }
    //}
}
