using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Color[] colors =
    {
        Color.FromRgb(255,0,0),
        Color.FromRgb(255,162,0),
        Color.FromRgb(255,255,0),
        Color.FromRgb(0,255,0),
        Color.FromRgb(0,0,255),
        Color.FromRgb(255,0,255),
        Color.FromRgb(0,255,255),
    };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox != null) && (richTextBox.Selection.Text.Length > 0);
        }
        private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox.Copy();
        }
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox.Paste();
        }
        private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (richTextBox != null) && (richTextBox.Selection.Text.Length > 0);
        }

        private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox.Cut();
        }
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox.Paste();
        }
        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox.Paste();
        }
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }
    }
}
