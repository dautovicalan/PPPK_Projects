/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.dao;

import com.alan.model.Kolegij;
import com.alan.model.Profesor;
import com.alan.model.Student;
import java.util.List;

/**
 *
 * @author Alan
 */
public interface Repository {
    
    int addStudent(Student data) throws Exception;
    void deleteStudent(Student student) throws Exception;
    List<Student> getStudents() throws Exception;
    Student getStudent(int idStudent) throws Exception;
    void updateStudent(Student student) throws Exception;
    
    int addProfesor(Profesor data) throws Exception;
    void deleteProfesor(Profesor profesor) throws Exception;
    List<Profesor> getProfesors() throws Exception;
    Profesor getProfesor(int idProfesor) throws Exception;
    void updateProfesor(Profesor profesor) throws Exception;
    
    int addKolegij(Kolegij data) throws Exception;
    void deleteKolegij(Kolegij kolegij) throws Exception;
    List<Kolegij> getKolegijs() throws Exception;
    Kolegij getKolegij(int idKolegij) throws Exception;
    void updateKolegij(Kolegij kolegij) throws Exception;
    
    default void release() throws Exception{};
}
