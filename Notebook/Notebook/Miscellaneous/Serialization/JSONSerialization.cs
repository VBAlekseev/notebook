using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Notebook
   {
   public class JSONSerialization : IDataSerialization
      {
      public ObservableCollection<Person> Open(string filename)
         {
         ObservableCollection<Person> persons = new ObservableCollection<Person>();
         DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Person>));
         using(FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate))
            {
            persons = jsonFormatter.ReadObject(fileStream) as ObservableCollection<Person>; 
            }

         return persons;
         }

      public void Save(string filename, ObservableCollection<Person> phonesList)
         {
         DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Person>));
         using(FileStream fileStream = new FileStream(filename, FileMode.Create))
            { jsonFormatter.WriteObject(fileStream, phonesList); }
         }
      }
   }
