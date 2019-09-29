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
using System.Windows.Shapes;
using DeansOffice.DAL;

namespace DeansOffice
{
    /// <summary>
    /// Логика взаимодействия для DialogueWindowAdd.xaml
    /// </summary>
    public partial class DialogueWindowAdd : Window
    {
        Student studentEdit;
        int status = 0;
        StudentsDbService sds = new StudentsDbService();
        Student student;
        MainWindow mainWindow;
        public DialogueWindowAdd(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            List<string> studies = sds.getStudies();
            List<string> subjects = sds.getSubjects();

            for (int i = 0; i < studies.Count; i++)
            {
                Studia.Items.Add(studies[i]);
            }

            for (int i = 0; i < subjects.Count; i++)
            {
                Przedmioty.Items.Add(subjects[i]);
            }
        }

        public DialogueWindowAdd(Student student, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            studentEdit = student;
            status = 1;
            InitializeComponent();
            this.student = student;
            Nazwisko_TxtBox.Text = student.LastName;
            Imie.Text = student.FirstName;
            NrIndeksu.Text = student.IndexNumber;
            Studia.SelectedItem = student.IdStudies;
                      


            List<string> studies = sds.getStudies();
            List<string> subjects = sds.getSubjects();

            for (int i = 0; i < studies.Count; i++)
            {
                Studia.Items.Add(studies[i]);
            }

            for (int i = 0; i < subjects.Count; i++)
            {
                Przedmioty.Items.Add(subjects[i]);
            }

            ButtonAdd.Content = "Edytuj";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (status == 0)
            {
                List<int> selectedSubjects = new List<int>();
                for (int i = 0; i < Przedmioty.Items.Count; i++)
                {
                    for (int j = 0; j < Przedmioty.SelectedItems.Count; j++)
                    {
                        if (Przedmioty.Items[i].Equals(Przedmioty.SelectedItems[j]))
                        {
                            selectedSubjects.Add(i);
                            break;
                        }
                    }


                }
                sds.addStudent(Imie.Text, Nazwisko_TxtBox.Text, NrIndeksu.Text, Studia.SelectedIndex, selectedSubjects);
                mainWindow.ListaStudentow.Add(new Student { IdStudent = sds.getLastId(), FirstName = Imie.Text, LastName = Nazwisko_TxtBox.Text, IndexNumber = NrIndeksu.Text, IdStudies = (string)Studia.SelectedItem, Subjects = selectedSubjects });
                mainWindow.LoadData();
            }
            else
            {
                List<int> selectedSubjects = new List<int>();
                for (int i = 0; i < Przedmioty.Items.Count; i++)
                {
                    for (int j = 0; j < Przedmioty.SelectedItems.Count; j++)
                    {
                        if (Przedmioty.Items[i].Equals(Przedmioty.SelectedItems[j]))
                        {
                            selectedSubjects.Add(i);
                            break;
                        }
                    }
                    

                }
                sds.updateData(Convert.ToInt32(studentEdit.IdStudent), Imie.Text, Nazwisko_TxtBox.Text, NrIndeksu.Text, Studia.SelectedIndex, selectedSubjects);

                for (int i = 0; i < mainWindow.ListaStudentow.Count; i++)
                {
                    if (mainWindow.ListaStudentow[i].IdStudent.Equals(studentEdit.IdStudent))
                    {
                        mainWindow.ListaStudentow[i].FirstName = Imie.Text;
                        mainWindow.ListaStudentow[i].LastName = Nazwisko_TxtBox.Text;
                        mainWindow.ListaStudentow[i].IndexNumber = NrIndeksu.Text;
                        mainWindow.ListaStudentow[i].IdStudies = (string)Studia.SelectedItem;
                        mainWindow.ListaStudentow[i].Subjects = selectedSubjects;
                        break;
                    }
                }

                mainWindow.LoadData();
            }
            
            

            Close();
        }
    }
}
