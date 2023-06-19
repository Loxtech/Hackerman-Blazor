using System.Data.SqlClient;

namespace HackermanBlazor.Data
{
    public class StudentService
    {
        private string conString = "Data Source=192.168.1.2;Initial Catalog=MyDB;User ID=sa;Password=Passw0rd;";
        

        public List<Students> ReadStudents(string query)
        {
            List<Students> list = new();
            using (SqlConnection con = new(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Students student = new();
                    student.Id = (int)reader[0];
                    student.FirstName = (string)reader[1];
                    student.LastName = (string)reader[2];
                    student.Age = (int)reader[3];
                    student.City = (string)reader[4];
                    student.Road = (string)reader[5];
                    student.Hobby = (string)reader[6];
                    list.Add(student);
                }
                con.Close();
            }
            return list;
        }

        public void deleteRow(int id)
        {
            using (SqlConnection con = new(conString))
            {
                SqlCommand cmd = new SqlCommand("Delete FROM Students WHERE Id=" + id, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void CreateStudents(Students st)
        {
            using(SqlConnection con = new(conString)) 
            {
                string query = $"INSERT INTO Students (FirstName, LastName, Age, City, Road, Hobby) VALUES (@FirstName, @LastName, @Age, @City, @Road, @Hobby)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@FirstName",System.Data.SqlDbType.NVarChar).Value = st.FirstName;
                if (st.FirstName == null) st.FirstName = "First Name not specified";
                cmd.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = st.LastName;
                if (st.LastName == null) st.LastName = "Last Name not specified";
                cmd.Parameters.Add("@Age", System.Data.SqlDbType.NVarChar).Value = st.Age;
                cmd.Parameters.Add("@City", System.Data.SqlDbType.NVarChar).Value = st.City;
                if (st.City == null) st.City = "City not specified";
                cmd.Parameters.Add("@Road", System.Data.SqlDbType.NVarChar).Value = st.Road;
                if (st.Road == null) st.Road = "Road not specified";
                cmd.Parameters.Add("@Hobby", System.Data.SqlDbType.NVarChar).Value = st.Hobby;
                if (st.Hobby == null) st.Hobby = "Hobby not specified";


                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception )
                {

                    throw;
                }
                con.Close();
            }
        }

    }
}
