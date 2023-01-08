using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCSH2_BTEJA.Model;
using Microsoft.Win32;
using System.Threading;

namespace BCSH2_BTEJA.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {

        public MyICommand StartCommand { get; set; }
        public MyICommand LoadCommand { get; set; }
        public MyICommand SaveCommand { get; set; }

        private ObservableCollection<Token> tokens;
        private ObservableCollection<string> messages;
        private string input;
        private ObservableCollection<object> output;
        public ObservableCollection<Token> Tokens
        {
            get { return this.tokens; }
            set { this.tokens = value;
                RaisePropertyChanged("Tokens");
                }
        }
        public ObservableCollection<string> Messages
        {
            get { return this.messages; }
            set
            {
                this.messages = value;
                RaisePropertyChanged("Messages");
            }
        }

        public string Input
        {
            get { return this.input; }
            set { this.input = value;
                StartCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged("Input");
            }
        }



        public ObservableCollection<object> Output
        {
            get { return this.output; }
            set
            {
                this.output = value;
                RaisePropertyChanged("Output");
            }
        }
        private AST astProg;
        private Lexer lexer;
        private Parser parser;

        public ViewModel()
        {
            StartCommand = new MyICommand(OnStart, CanStart);
            LoadCommand = new MyICommand(OnLoad, CanLoad);
            SaveCommand = new MyICommand(OnSave, CanSave);
            lexer = new Lexer();
            astProg = new AST();
            Input = System.IO.File.ReadAllText("C:/Users/Radek/Documents/GitHub/BCSH2-BTEJA_projekt_st64175/input.txt");
            Messages = new ObservableCollection<string>();
            Messages.Clear();
            Output = new ObservableCollection<object>();
            Output.Clear();
            Tokens = new ObservableCollection<Token>();
            Tokens.Clear();
        }


        private void OnSave()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";
            save.ShowDialog();
            StreamWriter writer = new StreamWriter(save.OpenFile());
            writer.Write(Input);
            writer.Dispose();
            writer.Close();
        }
        private bool CanSave()
        {
            if(input != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnLoad()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text files (*.txt)|*.txt";
            op.ShowDialog();
            var fileStream = op.OpenFile();
            string fileString = "";
            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileString = reader.ReadToEnd();
                Input = fileString;
            }
        }

        private bool CanLoad()
        {
            return true;
        }

        private void Start()
        {
            try
            {
                Tokens = null;
                Tokens = Lexing();
                Parsing();
                Running(Output);
            }catch (Exception ex)
            {
                Messages.Add(ex.Message);
            }
        }

        private void OnStart()
        {
             Thread t = new Thread(new ThreadStart(Start));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private bool CanStart()
        {
            return Input != null;
        }

        private ObservableCollection<Token> Lexing()
        {   
            ObservableCollection<Token> toks = new ObservableCollection<Token>();
            AddMessage("Started Lexing");
            toks = lexer.Run(Input);
            AddMessage("Lexing Finished");
            return toks;
        }

        private void Parsing()
        {
            AddMessage("Started Parsing");
            parser = new Parser(Tokens);
            astProg = parser.Parse();
            AddMessage("Finished Parsing");
        }

        private void Running(ObservableCollection<object> outp)
        {
            AddMessage("Started Program");
            Output = astProg.Run(outp);
            AddMessage("Finished Program");
        }


        public new void AddMessage(string mes)
        {
            Messages.Add(mes);
            if (null != PropertyChanged)
            {
                RaisePropertyChanged("Messages");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
