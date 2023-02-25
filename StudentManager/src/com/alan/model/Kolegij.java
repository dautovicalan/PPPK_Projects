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
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Alan
 */
@Entity
@Table(name = "Kolegij")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = HibernateFactory.SELECT_KOLEGIJS, query = "SELECT p FROM Kolegij p")
})
public class Kolegij implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "IDKolegij")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer iDKolegij;
    @Column(name = "KolegijName")
    private String kolegijName;
    @JoinColumn(name = "ProfesorID", referencedColumnName = "IDProfesor")
    @ManyToOne
    private Profesor profesorID;

    public Kolegij() {
    }
    
    public Kolegij(Kolegij data){
        updateDetails(data);
    }
    
    public Kolegij(Integer iDKolegij) {
        this.iDKolegij = iDKolegij;
    }
       
    
    public Kolegij(Integer iDKolegij, String kolegijName, Profesor profesor){
        this.iDKolegij = iDKolegij;
        this.kolegijName = kolegijName;
        this.profesorID = profesor;
    }

    

    public Integer getIDKolegij() {
        return iDKolegij;
    }

    public void setIDKolegij(Integer iDKolegij) {
        this.iDKolegij = iDKolegij;
    }

    public String getKolegijName() {
        return kolegijName;
    }

    public void setKolegijName(String kolegijName) {
        this.kolegijName = kolegijName;
    }

    public Profesor getProfesorID() {
        return profesorID;
    }

    public void setProfesorID(Profesor profesorID) {
        this.profesorID = profesorID;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (iDKolegij != null ? iDKolegij.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Kolegij)) {
            return false;
        }
        Kolegij other = (Kolegij) object;
        if ((this.iDKolegij == null && other.iDKolegij != null) || (this.iDKolegij != null && !this.iDKolegij.equals(other.iDKolegij))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.alan.model.Kolegij[ iDKolegij=" + iDKolegij + " ]";
    }

    public void updateDetails(Kolegij data) {
        this.kolegijName = data.getKolegijName();
        this.profesorID = data.getProfesorID();
    }
    
}
