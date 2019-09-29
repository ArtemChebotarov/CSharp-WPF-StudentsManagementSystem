using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using DeansOffice.DAL;

namespace DeansOffice
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<Student> ListaStudentow = new ObservableCollection<Student>();
        StudentsDbService sds = new StudentsDbService();
        public MainWindow()
		{
			InitializeComponent();

			
			ListaStudentow = sds.getDataDB();
            LoadData();
			
		}

        private void StudentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int selectedRowsCount = StudentsGrid.SelectedItems.Count;
            StudentsCount.Content = "Wybrałeś " + selectedRowsCount + " studentów";
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(StudentsGrid.SelectedItem != null)
            {
                DialogueWindow dialogueWindow = new DialogueWindow(this);
                dialogueWindow.Show();
            }
            
            
            
        }

        public void Delete()
        {
            foreach (Student row in StudentsGrid.SelectedItems)
            {

                ListaStudentow.Remove(row);
                sds.deleteDataDB(Convert.ToInt32(row.IdStudent));

            }
            LoadData();
        }

        public void LoadData()
        {
            StudentsGrid.Items.Clear();
            for (int i = 0; i < ListaStudentow.Count; i++)
            {
                StudentsGrid.Items.Add(ListaStudentow[i]);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogueWindowAdd dialogueWindowAdd = new DialogueWindowAdd(this);
            dialogueWindowAdd.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            
                DialogueWindowAdd dialogueWindowAdd = new DialogueWindowAdd((Student)StudentsGrid.SelectedItem, this);
                dialogueWindowAdd.Info.Content = "Edycja studenta";
                dialogueWindowAdd.Show();
            
            
        }
    }
}
