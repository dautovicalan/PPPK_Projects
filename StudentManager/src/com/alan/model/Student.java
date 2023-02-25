/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.model;

import com.alan.dao.sql.HibernateFactory;
import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Alan
 */
@Entity
@Table(name = "Student")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = HibernateFactory.SELECT_STUDENTS, query = "SELECT s FROM Student s")
})
public class Student implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "IDStudent")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer iDStudent;
    @Column(name = "FirstName")
    private String firstName;
    @Column(name = "LastName")
    private String lastName;
    @Column(name = "Email")
    private String email;
    @Column(name = "YearOfStudy")
    private Integer yearOfStudy;
    @Lob
    @Column(name = "Picture")
    private byte[] picture;

    public Student() {
    }
    
    public Student(Student data) {
        updateDetails(data);
    }

    public Student(Integer iDStudent) {
        this.iDStudent = iDStudent;
    }

    public Student(Integer idStudent, String firstName, String lastName, String email, int yearOfStudy) {
        this.iDStudent = idStudent;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.yearOfStudy = yearOfStudy;
    }

    public Integer getIDStudent() {
        return iDStudent;
    }

    public void setIDStudent(Integer iDStudent) {
        this.iDStudent = iDStudent;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Integer getYearOfStudy() {
        return yearOfStudy;
    }

    public void setYearOfStudy(Integer yearOfStudy) {
        this.yearOfStudy = yearOfStudy;
    }

    public byte[] getPicture() {
        return picture;
    }

    public void setPicture(byte[] picture) {
        this.picture = picture;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (iDStudent != null ? iDStudent.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Student)) {
            return false;
        }
        Student other = (Student) object;
        if ((this.iDStudent == null && other.iDStudent != null) || (this.iDStudent != null && !this.iDStudent.equals(other.iDStudent))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.alan.model.Student[ iDStudent=" + iDStudent + " ]";
    }
    
    public void updateDetails(Student data) {
        this.firstName = data.getFirstName();
        this.lastName = data.getLastName();
        this.yearOfStudy = data.getYearOfStudy();
        this.email = data.getEmail();
        this.picture = data.getPicture();
    }
    
}
