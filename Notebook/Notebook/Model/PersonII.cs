using System;
using System.ComponentModel;
using System.Text;

namespace Notebook
   {
   public partial class Person : IDataErrorInfo
      {


      public string Error
         {
         get
            {
            string error;
            StringBuilder sb = new StringBuilder();

            error = this["FirstName"];
            if(error != string.Empty)
               sb.AppendLine(error);

            error = this["LastName"];
            if(error != string.Empty)
               sb.AppendLine(error);

            error = this["Year"];
            if(error != string.Empty)
               sb.AppendLine(error);

            error = this["Phone"];
            if(error != string.Empty)
               sb.AppendLine(error);

            if(!string.IsNullOrEmpty(sb.ToString()))
               return sb.ToString();

            return "";
            }
         }

      public string this[string columnName]
         {
         get
            {
            switch(columnName)
               {
               case "FirstName":
                     {
                     if(string.IsNullOrEmpty(this.FirstName))
                        return "Введите имя!!!";
                     break;
                     }
               case "LastName":
                     {
                     if(string.IsNullOrEmpty(this.LastName))
                        return "Введите фамилию!!!";
                     break;
                     }
               case "Year":
                     {
                     if(Year < 0)
                        return "Год не может быть отрицательным";
                     if((DateTime.Now.Year - Year) > Properties.Settings.Default.maxAge)
                        return String.Format("Возраст не должен быть больше максимального возраста: {0}.", Properties.Settings.Default.maxAge);
                     if(Year > DateTime.Now.Year)
                        return String.Format("Год не может быть больше текущего: {0}.", Properties.Settings.Default.maxAge);
                     break;
                     }
               case "Phone":
                     {
                     if(string.IsNullOrEmpty(this.Phone))
                        return "Введите телефон!!!";
                     break;
                     }
               default:
                  break;
               }
            return "";
            }
         }
      }


   //public string this[string columnName]
   //      {
   //      get
   //         {
   //         string error = String.Empty;
   //         switch(columnName)
   //            {
   //            case "Year":
   //               if((Year < 0) || (Year > 120))
   //                  {
   //                  error = "Возраст должен быть больше 0 и меньше 100";
   //                  MessageBox.Show("Возраст должен быть не больше 125 лет.");
   //                  }
   //               break;
   //            case "FirsName":
   //               //Обработка ошибок для свойства Name
   //               break;
   //            case "LastName":
   //               //Обработка ошибок для свойства Position
   //               break;
   //            case "PhoneNuber":
   //               break;
   //            }
   //         return error;
   //         }
   //      }
   //   public string Error
   //      {
   //      get { throw new NotImplementedException(); }
   //      }

   }

   //public interface IDataErrorInfo
   //   {
   //   string Error { get; }
   //   string this[string columnName] { get; }
   //   }
   
   
