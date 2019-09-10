using System;
using System.Windows;

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
