using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Zadatak.Models;
using Zadatak.Utils;

namespace Zadatak.Dal
{
    class SqlRepository : IRepository
    {   // cannot be const
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
       
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Student.FirstName), student.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Student.LastName), student.LastName);
                    cmd.Parameters.AddWithValue(nameof(Student.Email), student.Email);
                    cmd.Parameters.AddWithValue(nameof(Student.YearOfStudy), student.YearOfStudy);
                    cmd.Parameters.Add(new SqlParameter(nameof(Student.Picture), SqlDbType.Binary, student.Picture.Length)
                    {
                        Value = student.Picture
                    });
                    SqlParameter idPerson = new SqlParameter(nameof(Student.IDStudent), SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idPerson);
                    cmd.ExecuteNonQuery();
                    student.IDStudent = (int)idPerson.Value;
                }
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Student.IDStudent), student.IDStudent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Student> GetStudents()
        {
            IList<Student> people = new List<Student>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(ReadStudent(dr));
                        }
                    }
                }
            }
            return people;
        }

        public Student GetStudent(int idStudent)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Student.IDStudent), idStudent);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadStudent(dr);
                        }
                    }
                }
            }
            throw new Exception("Student does not exist");
        }

        private static Student ReadStudent(SqlDataReader dr) => new Student
        {
            IDStudent = (int)dr[nameof(Student.IDStudent)],
            FirstName = dr[nameof(Student.FirstName)].ToString(),
            LastName = dr[nameof(Student.LastName)].ToString(),            
            Email = dr[nameof(Student.Email)].ToString(),
            YearOfStudy = (int)dr[nameof(Student.YearOfStudy)],
            Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 5)
        };

        public void UpdateStudent(Student person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Student.FirstName), person.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Student.LastName), person.LastName);
                    cmd.Parameters.AddWithValue(nameof(Student.Email), person.Email);
                    cmd.Parameters.AddWithValue(nameof(Student.YearOfStudy), person.YearOfStudy);
                    cmd.Parameters.AddWithValue(nameof(Student.IDStudent), person.IDStudent);
                    cmd.Parameters.Add(new SqlParameter(nameof(Student.Picture), SqlDbType.Binary, person.Picture.Length)
                    {
                        Value = person.Picture
                    });
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddProfesor(Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Profesor.FirstName), profesor.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Profesor.LastName), profesor.LastName);
                    cmd.Parameters.AddWithValue(nameof(Profesor.Email), profesor.Email);
                    cmd.Parameters.Add(new SqlParameter(nameof(Profesor.Picture), SqlDbType.Binary, profesor.Picture.Length)
                    {
                        Value = profesor.Picture
                    });
                    SqlParameter idPerson = new SqlParameter(nameof(Profesor.IDProfesor), SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idPerson);
                    cmd.ExecuteNonQuery();
                    profesor.IDProfesor = (int)idPerson.Value;
                }
            }
        }

        public void DeleteProfesor(Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Profesor.IDProfesor), profesor.IDProfesor);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Profesor> GetProfesors()
        {
            IList<Profesor> people = new List<Profesor>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(ReadProfesor(dr));
                        }
                    }
                }
            }
            return people;
        }


        public Profesor GetProfesor(int idProfesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Profesor.IDProfesor), idProfesor);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadProfesor(dr);
                        }
                    }
                }
            }
            throw new Exception("Profesor does not exist");
        }

        private static Profesor ReadProfesor(SqlDataReader dr, int pictureColumn = 4) => new Profesor
        {
            IDProfesor = (int)dr[nameof(Profesor.IDProfesor)],
            FirstName = dr[nameof(Profesor.FirstName)].ToString(),
            LastName = dr[nameof(Profesor.LastName)].ToString(),
            Email = dr[nameof(Profesor.Email)].ToString(),
            Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, pictureColumn)
        };

        public void UpdateProfesor(Profesor profesor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Profesor.FirstName), profesor.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Profesor.LastName), profesor.LastName);
                    cmd.Parameters.AddWithValue(nameof(Profesor.Email), profesor.Email);
                    cmd.Parameters.AddWithValue(nameof(Profesor.IDProfesor), profesor.IDProfesor);
                    cmd.Parameters.Add(new SqlParameter(nameof(Profesor.Picture), SqlDbType.Binary, profesor.Picture.Length)
                    {
                        Value = profesor.Picture
                    });
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AddKolegij(Kolegij kolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Kolegij.KolegijName), kolegij.KolegijName);
                    cmd.Parameters.AddWithValue(nameof(Kolegij.ProfesorID), kolegij.ProfesorID);
                    SqlParameter idKolegij = new SqlParameter(nameof(Kolegij.IDKolegij), SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idKolegij);
                    cmd.ExecuteNonQuery();
                    kolegij.IDKolegij = (int)idKolegij.Value;
                }
            }
        }

        public void DeleteKolegij(Kolegij kolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Kolegij.IDKolegij), kolegij.IDKolegij);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateKolegij(Kolegij kolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue(nameof(Kolegij.KolegijName), kolegij.KolegijName);
                    cmd.Parameters.AddWithValue(nameof(Kolegij.ProfesorID), kolegij.ProfesorID);
                    cmd.Parameters.AddWithValue(nameof(Kolegij.IDKolegij), kolegij.IDKolegij);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Kolegij GetKolegij(int idKolegij)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(nameof(Kolegij.IDKolegij), idKolegij);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadKolegij(dr);
                        }
                    }
                }
            }
            throw new Exception("Kolegij does not exist");
        }

        public IList<Kolegij> GetKolegijs()
        {
            IList<Kolegij> kolegijs = new List<Kolegij>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            kolegijs.Add(ReadKolegij(dr));
                        }
                    }
                }
            }
            return kolegijs;
        }

        private static Kolegij ReadKolegij(SqlDataReader dr) => new Kolegij
        {
            IDKolegij = (int)dr[nameof(Kolegij.IDKolegij)],
            KolegijName = dr[nameof(Kolegij.KolegijName)].ToString(),            
            Profesor = ReadProfesor(dr, 6),
            ProfesorID = (int)dr[nameof(Profesor.IDProfesor)]
        };
    }
}
