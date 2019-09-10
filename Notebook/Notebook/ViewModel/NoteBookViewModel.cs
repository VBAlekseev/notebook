using System.ComponentModel;
using System.Collections.ObjectModel;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace Notebook
   {
   [Serializable]
   public class NoteBookViewModel : NotifyPropertyChanged
      {
      IDataSerialization serializer;
      IDialog dialogWindow;
      

      private Person selectedPerson;
      

      public ObservableCollection<Person> Persons { get; set; }

      public Person SelectedPerson
         {
         get { return selectedPerson; }
         set
            {
            selectedPerson = value;
            OnPropertyChanged("SelectedPerson");
            }
         }
      

      public string FilterText
         {
         get { return (string) GetValue(FilterTextProperty); }
         set { SetValue(FilterTextProperty, value); }
         }
      public static readonly DependencyProperty FilterTextProperty =
          DependencyProperty.Register("FilterText", typeof(string), typeof(NoteBookViewModel), new PropertyMetadata("", FilterText_Changed));

      private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
         {
         var current = d as NoteBookViewModel;
         if (current != null)
            {
            current.Items.Filter = null;
            current.Items.Filter = current.FilterPerson;
            }
         }
      
      private bool FilterPerson(object obj)
         {
         bool result = true;
         Person current = obj as Person;
         if((current != null) &&
            (!string.IsNullOrWhiteSpace(FilterText) &&
             !current.FirstName.Contains(FilterText) &&
             !current.LastName.Contains(FilterText) &&
             !current.Phone.Contains(FilterText)
             ))
            { return result = false; }
         return result;
         }

      public ICollectionView Items
         {
         get { return (ICollectionView) GetValue(MyPropertyProperty); }
         set { SetValue(MyPropertyProperty, value); }
         }
      public static readonly DependencyProperty MyPropertyProperty =
          DependencyProperty.Register("Items", typeof(ICollectionView), typeof(NoteBookViewModel), new PropertyMetadata(null));
                     


      public NoteBookViewModel(IDataSerialization serializer) 
         {
         dialogWindow = new Dialog();

         Persons = new ObservableCollection<Person>();
         
         this.serializer = serializer;
         DialogWindowSettings();

         Persons = serializer.Open(Properties.Settings.Default.path);

         Items = CollectionViewSource.GetDefaultView(Persons);
         Items.Filter = FilterPerson;
         }
            

      // Command for creating new person.
      private Command addPersonCommand;
      public Command AddPersonCommand
         {
         get
            {
            return addPersonCommand ?? (addPersonCommand = new Command(obj =>
            {
               Person person = new Person();
               Persons.Add(person);
               SelectedPerson = person;
            }));
            }
         }
      
      // Command for deleting person.
      private Command removePersonCommand;
      public Command RemovePersonCommand
         {
         get
            {
            return removePersonCommand ?? (removePersonCommand = new Command(obj =>
                  {
                     Person person = obj as Person;
                     if(person != null)
                        {
                        Persons.Remove(person);
                        if(Persons.Count > 0)
                           { SelectedPerson = Persons[Persons.Count - 1]; }
                        }
                  },
                  (obj) => Persons.Count > 0));
            }
         }
                     
      // Command save is called from the main menu.
      private Command saveCommand;
      public Command SaveCommand
         {
         get
            {
            return saveCommand ?? (saveCommand = new Command(obj =>
                  {
                  try
                     {
                     if(dialogWindow.SaveFileDialog() == true)
                        {
                        serializer.Save(dialogWindow.FilePath, Persons);
                        Properties.Settings.Default.path = dialogWindow.FilePath;
                        dialogWindow.ShowMessage("Файл сохранен");
                        }
                     }
                  catch(Exception ex)
                     { dialogWindow.ShowMessage(ex.Message); }
                  }));
            }
         }

      // Command open is called from the main menu.
      private Command openCommand;
      public Command OpenCommand
         {
         get
            {
            return openCommand ?? (openCommand = new Command(obj =>
                  {
                  try
                     {
                     if(dialogWindow.OpenFileDialog() == true)
                        {
                        Persons.Clear();
                        var persons = serializer.Open(dialogWindow.FilePath);
                        foreach(var p in persons)
                           Persons.Add(p);
                        dialogWindow.ShowMessage("Файл открыт");
                        }
                     }
                 catch(Exception ex)
                    { dialogWindow.ShowMessage(ex.Message); }
              }));
            }
         }


      // The data storage method is called upon exit. 
      public void Save()
         { serializer.Save(Properties.Settings.Default.path, Persons); }

      private void DialogWindowSettings()
         {
         dialogWindow.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
         dialogWindow.Directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
         dialogWindow.FilterIndex = 0;
         }
      }
   }

