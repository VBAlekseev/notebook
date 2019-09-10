using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Notebook
   {
   public class NotifyPropertyChanged : DependencyObject, INotifyPropertyChanged
      {
      public event PropertyChangedEventHandler PropertyChanged;
      
      public void OnPropertyChanged([CallerMemberName]string prop = "")
         {
         if(PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
         }
      }
   }
