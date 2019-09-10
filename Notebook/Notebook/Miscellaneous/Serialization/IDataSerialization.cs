using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
   {
   public interface IDataSerialization
      {
      ObservableCollection<Person> Open(string filename);
      void Save(string filename, ObservableCollection<Person> phonesList);
      }
   }
