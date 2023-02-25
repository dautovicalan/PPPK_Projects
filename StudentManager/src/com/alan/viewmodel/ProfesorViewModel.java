/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.viewmodel;

import com.alan.model.Profesor;
import com.alan.model.Student;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.beans.property.SimpleObjectProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

/**
 *
 * @author Alan
 */
public class ProfesorViewModel {
    private final Profesor profesor;

    public ProfesorViewModel(Profesor profesor) {
        if (profesor == null) {
            profesor = new Profesor(0, "", "", "");
        }
        this.profesor = profesor;
    }

    public Profesor getProfesor() {
        return profesor;
    }

    public IntegerProperty getIdPersonProperty() {
        return new SimpleIntegerProperty(profesor.getIDProfesor());
    }

    public StringProperty getFirstNameProperty() {
        return new SimpleStringProperty(profesor.getFirstName());
    }

    public StringProperty getLastNameProperty() {
        return new SimpleStringProperty(profesor.getLastName());
    }

    public StringProperty getEmailProperty() {
        return new SimpleStringProperty(profesor.getEmail());
    }

    public ObjectProperty<byte[]> getPictureProperty() {
        return new SimpleObjectProperty<>(profesor.getPicture());
    }
}
