using Autofac;
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
         Application app = new Application();

         Bootstraper bootstraper = new Bootstraper();
         IContainer container = bootstraper.Bootsrap();
         NoteBookView window = container.Resolve<NoteBookView>();
         app.Run(window);
         }
      }
   }
