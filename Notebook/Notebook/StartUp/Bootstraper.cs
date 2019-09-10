using Autofac;

namespace Notebook
   {
   public class Bootstraper
      {
      public IContainer Bootsrap()
         {
         var builder = new ContainerBuilder();
         builder.RegisterType<NoteBookViewModel>().AsSelf();
         builder.RegisterType<NoteBookView>().AsSelf();
         builder.RegisterType<JSONSerialization>().As<IDataSerialization>();

         return builder.Build();
         }
      }
   }
