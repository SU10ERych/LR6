using LR6.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LR6.ViewModels
{
    internal class MyViewModel : INotifyPropertyChanged
    {
        private double result;
        private bool f1 = false;
        private bool f2 = false;
        public double Result
        {
            get { return result; }
            set { result = value; RaisePropertyChanged("Result"); }
        }

        public bool F1
        {
            get
            {
                return f1;
            }
            set
            {
                f1 = value;
                RaisePropertyChanged("F1");
            }
        }

        public bool F2
        {
            get
            {
                return f2;
            }
            set
            {
                f2 = value;
                RaisePropertyChanged("F2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public MyViewModel() { }


        private RelayCommand clickCommand;
        
        public RelayCommand ClickCommand
        {
            get
            {
                return clickCommand ??
                    (clickCommand = new RelayCommand(obj =>
                    {
                        Numbers numbers = new Numbers();
                        if (f1)
                            Result = numbers.returnTreangle();
                        else if (f2)
                            Result = numbers.returnSquare();
                        else
                            Result = 0;
                    }));
            }
        }

        private RelayCommand resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ?? 
                (resetCommand = new RelayCommand(obj =>
                {
                    Result = 0;
                    f1 = false;
                    f2 = false;
                }));
            }
        }
    }
}
