using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Archive.Generator.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var archiveGenerator = new ArchiveGenerator<BaseArchiveGenerator>();

            var generatorExample = new GeneratorExample();

            var header = generatorExample.GerarHeader(TxtNomeDaEmpresa.Text);

            archiveGenerator.GenerateFile(AppDomain.CurrentDomain.BaseDirectory, "CNAB400_example.txt",
                new List<BaseArchiveGenerator>
                {
                    header
                });

            MessageBox.Show(this, "Arquivo gerado com sucesso!");

            Process.Start("notepad.exe", $"{AppDomain.CurrentDomain.BaseDirectory}\\CNAB400_example.txt");
        }
    }
}