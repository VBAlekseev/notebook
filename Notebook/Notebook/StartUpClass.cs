using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notebook
   {
   class StartUpClass
      {

      
      
      [STAThread]
      public static void Main(string [] args)
         {
         JSONSerialization serialization = new JSONSerialization();
         NoteBookViewModel noteBookViewModel = new NoteBookViewModel(new Dialog(), serialization);
         


         Application app = new Application();
         NoteBookView window = new NoteBookView(noteBookViewModel);
         app.Run(window);
         }


     

      }
   }
