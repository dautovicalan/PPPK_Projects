/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.viewmodel;

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
public class StudentViewModel {
    private final Student student;

    public StudentViewModel(Student student) {
        if (student == null) {
            student = new Student(0, "", "", "", 0);
        }
        this.student = student;
    }

    public Student getPerson() {
        return student;
    }

    public IntegerProperty getIdPersonProperty() {
        return new SimpleIntegerProperty(student.getIDStudent());
    }

    public StringProperty getFirstNameProperty() {
        return new SimpleStringProperty(student.getFirstName());
    }

    public StringProperty getLastNameProperty() {
        return new SimpleStringProperty(student.getLastName());
    }

    public StringProperty getEmailProperty() {
        return new SimpleStringProperty(student.getEmail());
    }

    public StringProperty getYearOfStudyProperty() {
        return new SimpleStringProperty(student.getYearOfStudy().toString());
    }

    public ObjectProperty<byte[]> getPictureProperty() {
        return new SimpleObjectProperty<>(student.getPicture());
    }
}
