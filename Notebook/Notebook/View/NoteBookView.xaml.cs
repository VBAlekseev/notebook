using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notebook

   {
   public partial class NoteBookView : Window
      {
      NoteBookViewModel noteBookViewModel;
           

      public NoteBookView()
         {
         InitializeComponent();
         
         Loaded += NoteBookView_Loaded;
         Closed += NoteBookView_Closed;
         }

      public NoteBookView(NoteBookViewModel noteBookViewModel) : this()
         { this.noteBookViewModel = noteBookViewModel; }


      private void NoteBookView_Closed(object sender, EventArgs e)
         {
         noteBookViewModel.Save();
         Properties.Settings.Default.Save();
         }

      private void NoteBookView_Loaded(object sender, RoutedEventArgs e)
         { DataContext = noteBookViewModel; }
      }
   }
