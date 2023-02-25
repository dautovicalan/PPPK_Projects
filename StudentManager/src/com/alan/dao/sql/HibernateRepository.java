/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.dao.sql;

import com.alan.dao.Repository;
import com.alan.model.Kolegij;
import com.alan.model.Profesor;
import com.alan.model.Student;
import java.util.List;
import javax.persistence.EntityManager;

/**
 *
 * @author Alan
 */
public class HibernateRepository implements Repository{

    @Override
    public int addStudent(Student data) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // in order to use in in transaction scope, we must create new Person that with data details
            Student student = new Student(data);
            em.persist(student);
            em.getTransaction().commit();
            return student.getIDStudent();
        }
    }

    @Override
    public void deleteStudent(Student student) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            
            em.remove(em.contains(student) ? student : em.merge(student));
            em.getTransaction().commit();
        }
    }

    @Override
    public List<Student> getStudents() throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            return entityManager.get().createNamedQuery(HibernateFactory.SELECT_STUDENTS).getResultList();
        }
    }

    @Override
    public Student getStudent(int idStudent) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            return em.find(Student.class, idStudent);
        }
    }

    @Override
    public void updateStudent(Student student) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            
            em.find(Student.class, student.getIDStudent()).updateDetails(student);
            em.getTransaction().commit();
        }
    }

    @Override
    public int addProfesor(Profesor data) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // in order to use in in transaction scope, we must create new Person that with data details
            Profesor profesor = new Profesor(data);
            em.persist(profesor);
            em.getTransaction().commit();
            return profesor.getIDProfesor();
        }
    }

    @Override
    public void deleteProfesor(Profesor profesor) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            
            em.remove(em.contains(profesor) ? profesor : em.merge(profesor));
            em.getTransaction().commit();
        }
    }

    @Override
    public List<Profesor> getProfesors() throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            return entityManager.get().createNamedQuery(HibernateFactory.SELECT_PROFESORS).getResultList();
        }
    }

    @Override
    public Profesor getProfesor(int idProfesor) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            return em.find(Profesor.class, idProfesor);
        }
    }

    @Override
    public void updateProfesor(Profesor profesor) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            
            em.find(Profesor.class, profesor.getIDProfesor()).updateDetails(profesor);
            em.getTransaction().commit();
        }
    }

    @Override
    public int addKolegij(Kolegij data) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // in order to use in in transaction scope, we must create new Person that with data details
            Kolegij kolegij = new Kolegij(data);
            em.persist(kolegij);
            em.getTransaction().commit();
            return kolegij.getIDKolegij();
        }
    }

    @Override
    public void deleteKolegij(Kolegij kolegij) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            
            em.remove(em.contains(kolegij) ? kolegij : em.merge(kolegij));
            em.getTransaction().commit();
        }
    }

    @Override
    public List<Kolegij> getKolegijs() throws Exception {
         try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            return entityManager.get().createNamedQuery(HibernateFactory.SELECT_KOLEGIJS).getResultList();
        }
    }

    @Override
    public Kolegij getKolegij(int idKolegij) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            return em.find(Kolegij.class, idKolegij);
        }
    }

    @Override
    public void updateKolegij(Kolegij kolegij) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()){
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            
            em.find(Kolegij.class, kolegij.getIDKolegij()).updateDetails(kolegij);
            em.getTransaction().commit();
        }
    }

    @Override
    public void release() throws Exception {
        HibernateFactory.release();
    }
    
}
