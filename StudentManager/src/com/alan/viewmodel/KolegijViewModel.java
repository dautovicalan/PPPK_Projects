/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.viewmodel;

import com.alan.model.Kolegij;
import com.alan.model.Profesor;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author Alan
 */
public class KolegijViewModel {
    private final Kolegij kolegij;

    public KolegijViewModel(Kolegij kolegij) {
        if (kolegij == null) {
            kolegij = new Kolegij(0, "", new Profesor(0, "", "", ""));
        }
        this.kolegij = kolegij;
    }

    public Kolegij getKolegij() {
        return kolegij;
    }

    public IntegerProperty getIdKolegijProperty() {
        return new SimpleIntegerProperty(kolegij.getIDKolegij());
    }

    public StringProperty getKolegijNameProperty() {
        return new SimpleStringProperty(kolegij.getKolegijName());
    }
    
    public StringProperty getProfesorId(){
        return new SimpleStringProperty(kolegij.getProfesorID().toString());
    }

}
