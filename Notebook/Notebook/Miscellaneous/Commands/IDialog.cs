namespace Notebook
   {
   public interface IDialog
      {
      string Directory { get; set; }
      string FilePath { get; set; }
      string Filter { get; set; }
      int FilterIndex { get; set; }

      bool OpenFileDialog();
      bool SaveFileDialog();
      void ShowMessage(string message);
      }
   }