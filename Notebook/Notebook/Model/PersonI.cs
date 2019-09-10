using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;

namespace Notebook
   {
   public partial class Person : NotifyPropertyChanged//, IDataErrorInfo
      {
      private string firstName;
      private string lastName;
      private int year;
      private string phone;

      public string FirstName
         {
         get { return firstName; }
         set
            {
            firstName = value;
            OnPropertyChanged("FirstName");
            }
         }
      public string LastName
         {
         get { return lastName; }
         set
            {
            lastName = value;
            OnPropertyChanged("LastName");
            }
         }
      public int Year
         {
         get { return year; }
         set
            {
            year = value;
            OnPropertyChanged("Year");
            }
         }
      public string Phone
         {
         get { return phone; }
         set
            {
            phone = value;
            OnPropertyChanged("Phone");
            }
         }


      }
   }