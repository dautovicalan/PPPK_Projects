/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.model;

import com.alan.dao.sql.HibernateFactory;
import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Lob;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author Alan
 */
@Entity
@Table(name = "Profesor")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = HibernateFactory.SELECT_PROFESORS, query = "SELECT p FROM Profesor p")
})
public class Profesor implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "IDProfesor")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer iDProfesor;
    @Column(name = "FirstName")
    private String firstName;
    @Column(name = "LastName")
    private String lastName;
    @Column(name = "Email")
    private String email;
    @Lob
    @Column(name = "Picture")
    private byte[] picture;
    @OneToMany(mappedBy = "profesorID")
    private Collection<Kolegij> kolegijCollection;

    public Profesor() {
    }
    
    public Profesor(Profesor data){
        updateDetails(data);
    }

    public Profesor(Integer iDProfesor) {
        this.iDProfesor = iDProfesor;
    }

    public Profesor(Integer idProfesor, String firstName, String lastName, String email) {
        this.iDProfesor = idProfesor;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }

    public Integer getIDProfesor() {
        return iDProfesor;
    }

    public void setIDProfesor(Integer iDProfesor) {
        this.iDProfesor = iDProfesor;
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

    public byte[] getPicture() {
        return picture;
    }

    public void setPicture(byte[] picture) {
        this.picture = picture;
    }

    @XmlTransient
    public Collection<Kolegij> getKolegijCollection() {
        return kolegijCollection;
    }

    public void setKolegijCollection(Collection<Kolegij> kolegijCollection) {
        this.kolegijCollection = kolegijCollection;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (iDProfesor != null ? iDProfesor.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Profesor)) {
            return false;
        }
        Profesor other = (Profesor) object;
        if ((this.iDProfesor == null && other.iDProfesor != null) || (this.iDProfesor != null && !this.iDProfesor.equals(other.iDProfesor))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "ID - " + iDProfesor + ": " + firstName + " " + lastName;
    }
    
    public void updateDetails(Profesor data) {
        this.firstName = data.getFirstName();
        this.lastName = data.getLastName();
        this.email = data.getEmail();
        this.picture = data.getPicture();
    }
    
}
