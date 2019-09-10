using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Notebook
   {
   public class NotifyPropertyChanged : DependencyObject, INotifyPropertyChanged
      {
      public event PropertyChangedEventHandler PropertyChanged;
      
      protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
         { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
      }
   }
