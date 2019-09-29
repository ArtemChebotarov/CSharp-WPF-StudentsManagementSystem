using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DeansOffice.DAL
{
	class StudentsDbService
	{
		private ObservableCollection<Student> ListaStudentow = new ObservableCollection<Student>();
		public StudentsDbService()
		{
			
		}

		public ObservableCollection<Student> getDataDB()
		{
			string connectionString = "Data Source=db-mssql;Initial Catalog=s17062;Integrated Security=True;MultipleActiveResultSets=True";

			using (SqlConnection con = new SqlConnection(connectionString))
			{

				con.Open();

				using (SqlCommand command = new SqlCommand("SELECT * FROM apbd.Student s1 JOIN apbd.Studies s2 ON s1.idStudies = s2.idStudies", con))
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
                        string id = reader["IdStudent"].ToString();
						string imie = reader["FirstName"].ToString();
						string nazwisko = reader["LastName"].ToString();
						string nrIndeksu = reader["IndexNumber"].ToString();
						string adres = reader["Address"].ToString();
						string studia = reader["Name"].ToString();

						ListaStudentow.Add(new Student { IdStudent = id, IndexNumber = nrIndeksu, FirstName = imie, LastName = nazwisko, IdStudies = studia, Address = adres });

					}
				}
			}

			return ListaStudentow;
		}

        public void deleteDataDB(int id)
        {
            string connectionString = "Data Source=db-mssql;Initial Catalog=s17062;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                var tran = con.BeginTransaction();

                using (SqlCommand command = new SqlCommand("DELETE FROM apbd.Student_Subject WHERE IdStudent = @Id", con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.Transaction = tran;
                    command.ExecuteNonQuery();

                }

                using (SqlCommand command = new SqlCommand("DELETE FROM apbd.Student WHERE IdStudent = @Id", con))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.Transaction = tran;
                    command.ExecuteNonQuery();

                }
                tran.Commit();
                
            }

            
        }

        public List<string> getStudies()
        {
            List<string> studies;
            string connectionString = "Data Source=db-mssql;Initial Catalog=s17062;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();               
                using (SqlCommand command = new SqlCommand("SELECT * FROM apbd.Studies", con))

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    studies = new List<string>();
                    
                    while (reader.Read())
                    {
                        string studia = reader["Name"].ToString();
                        studies.Add(studia);
                        

                    }
                }
            }

            return studies;
        }

        public List<string> getSubjects()
        {
            List<string> subjects;
            string connectionString = "Data Source=db-mssql;Initial Catalog=s17062;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM apbd.Subject", con))

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    subjects = new List<string>();

                    while (reader.Read())
                    {
                        string studia = reader["Name"].ToString();
                        subjects.Add(studia);


                    }
                }
            }

            return subjects;
        }

        public void addStudent(string imie, string nazwisko, string nrIndeksu, int studia, List<int> selectedSubjects)
        {
            
            string connectionString = "Data Source=db-mssql;Initial Catalog=s17062;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                var tran = con.BeginTransaction();

                using (SqlCommand command = new SqlCommand("INSERT INTO apbd.Student VALUES(@FirstName, @LastName, @Address, @IndexNumber, @IdStudies)", con))
                {
                    command.Parameters.AddWithValue("@FirstName", imie);
                    command.Parameters.AddWithValue("@LastName", nazwisko);
                    command.Parameters.AddWithValue("@Address", "");
                    command.Parameters.AddWithValue("@IndexNumber", nrIndeksu);
                    command.Parameters.AddWithValue("@IdStudies", studia+1);

                    command.Transaction = tran;
                    command.ExecuteNonQuery();

                }

                for (int i = 0; i < selectedSubjects.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO apbd.Student_Subject VALUES ((SELECT MAX(IdStudent) FROM apbd.Student), @i, GETDATE())", con))
                    {
                        command.Parameters.AddWithValue("@i", selectedSubjects[i]+1);
                        command.Parameters.AddWithValue("@FirstName", imie);
                        command.Parameters.AddWithValue("@LastName", nazwisko);
                        command.Parameters.AddWithValue("@Address", "");
                        command.Parameters.AddWithValue("@IndexNumber", nrIndeksu);
                        command.Parameters.AddWithValue("@IdStudies", studia + 1);

                        command.Transaction = tran;
                        command.ExecuteNonQuery();

                    }
                }
                tran.Commit();

            }

        }

        public string getLastId()
        {
            string lastId = "-1";
            string connectionString = "Data Source=db-mssql;Initial Catalog=s17062;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM apbd.Student", con))

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        lastId = reader["IdStudent"].ToString();
                        


                    }
                }
            }

            return lastId;
        }

        public void updateData(int idStudent, string imie, string nazwisko, string nrIndeksu, int studia, List<int> selectedSubjects)
        {
            string connectionString = "Data Source=db-mssql;Initial Catalog=s17062;Integrated Security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                con.Open();
                var tran = con.BeginTransaction();

                using (SqlCommand command = new SqlCommand("UPDATE apbd.Student SET FirstName = @FirstName, LastName = @LastName, IndexNumber = @IndexNumber, IdStudies = @IdStudies WHERE IdStudent = @IdStudent", con))
                {
                    command.Parameters.AddWithValue("@FirstName", imie);
                    command.Parameters.AddWithValue("@LastName", nazwisko);
                    command.Parameters.AddWithValue("IdStudent", idStudent);
                    command.Parameters.AddWithValue("@IndexNumber", nrIndeksu);
                    command.Parameters.AddWithValue("@IdStudies", studia+1);

                    command.Transaction = tran;
                    command.ExecuteNonQuery();

                }

                using (SqlCommand command = new SqlCommand("DELETE FROM apbd.Student_Subject WHERE IdStudent = @IdStudent", con))
                {
                    
                    command.Parameters.AddWithValue("@IdStudent", idStudent);
                    

                    command.Transaction = tran;
                    command.ExecuteNonQuery();

                }


                for (int i = 0; i < selectedSubjects.Count; i++)
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO apbd.Student_Subject VALUES (@IdStudent, @i, GETDATE())", con))
                    {
                        command.Parameters.AddWithValue("@i", selectedSubjects[i]+1);
                        
                        command.Parameters.AddWithValue("@IdStudent", idStudent);

                        command.Transaction = tran;
                        command.ExecuteNonQuery();

                    }
                }



                tran.Commit();

            }
        }

    }

    
}

