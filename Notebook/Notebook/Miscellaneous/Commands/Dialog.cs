using Microsoft.Win32;
using System.Windows;

namespace Notebook
   {

   public class Dialog : IDialog
      {
      public string Filter { get; set; }

      public int FilterIndex { get; set; }

      public string FilePath { get; set; }

      public string Directory { get; set; }

      public bool OpenFileDialog()
         {
         OpenFileDialog openFileDialog = new OpenFileDialog();
         openFileDialog.InitialDirectory = Directory;
         openFileDialog.FilterIndex = FilterIndex;
         openFileDialog.Filter = Filter;
         if(openFileDialog.ShowDialog() == true)
            {
            FilePath = openFileDialog.FileName;
            return true;
            }
         return false;
         }

      public bool SaveFileDialog()
         {
         SaveFileDialog saveFileDialog = new SaveFileDialog();
         saveFileDialog.InitialDirectory = Directory;
         saveFileDialog.FilterIndex = FilterIndex;
         saveFileDialog.Filter = Filter;
         if(saveFileDialog.ShowDialog() == true)
            {
            FilePath = saveFileDialog.FileName;
            return true;
            }
         return false;
         }

      public void ShowMessage(string message)
         { MessageBox.Show(message); }
      }
   }
