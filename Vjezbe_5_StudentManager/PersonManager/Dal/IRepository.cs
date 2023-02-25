using System.Collections.Generic;
using Zadatak.Models;

namespace Zadatak.Dal
{
    public interface IRepository
    {
        void AddStudent(Student student);
        void DeleteStudent(Student student);
        IList<Student> GetStudents();
        Student GetStudent(int idStudent);
        void UpdateStudent(Student student);

        void AddProfesor(Profesor profesor);
        void DeleteProfesor(Profesor profesor);
        IList<Profesor> GetProfesors();
        Profesor GetProfesor(int idProfesor);
        void UpdateProfesor(Profesor profesor);

        void AddKolegij(Kolegij kolegij);
        void DeleteKolegij(Kolegij kolegij);
        void UpdateKolegij(Kolegij kolegij);
        Kolegij GetKolegij(int idKolegij);
        IList<Kolegij> GetKolegijs();
    }
}