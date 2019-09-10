using System.Collections.ObjectModel;

namespace Notebook
   {
   public interface IDataSerialization
      {
      ObservableCollection<Person> Open(string filename);
      void Save(string filename, ObservableCollection<Person> phonesList);
      }
   }
