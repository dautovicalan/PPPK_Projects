/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.controller;

import com.alan.dao.RepositoryFactory;
import com.alan.utilities.FileUtils;
import com.alan.utilities.ImageUtils;
import com.alan.utilities.ValidationUtils;
import com.alan.viewmodel.StudentViewModel;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.util.AbstractMap;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.concurrent.atomic.AtomicBoolean;
import java.util.function.UnaryOperator;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.TextFormatter;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.util.converter.IntegerStringConverter;

/**
 * FXML Controller class
 *
 * @author Alan
 */
public class StudentController implements Initializable {
    
    private Map<TextField, Label> validationMap;

    private final ObservableList<StudentViewModel> students = FXCollections.observableArrayList();

    private StudentViewModel selectedStudentViewModel;

    private Tab previousTab;

    @FXML
    private TabPane tpContent;
    @FXML
    private Tab tabEdit;
    @FXML
    private Tab tabList;
    @FXML
    private ImageView ivPerson;
    @FXML
    private TableView<StudentViewModel> tvStudents;
    @FXML
    private TableColumn<StudentViewModel, String> tcFirstName, tcLastName, tcEmail, tcYearOfStudy;    
    @FXML
    private TextField tfFirstName, tfLastName, tfEmail, tfYearOfStudy;
    @FXML
    private Label lbFirstNameError, lbLastNameError, lbEmailError, lbYearOfStudyError, lbIconError;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        initValidation();
        initPeople();
        initTable();
        addIntegerMask(tfYearOfStudy);
        setupListeners();
    }

    private void initValidation() {
        validationMap = Stream.of(new AbstractMap.SimpleImmutableEntry<>(tfFirstName, lbFirstNameError),
                new AbstractMap.SimpleImmutableEntry<>(tfLastName, lbLastNameError),
                new AbstractMap.SimpleImmutableEntry<>(tfYearOfStudy, lbYearOfStudyError),
                new AbstractMap.SimpleImmutableEntry<>(tfEmail, lbEmailError))
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initPeople() {
        try {
            RepositoryFactory.getRepository().getStudents().forEach(student -> students.add(new StudentViewModel(student)));
        } catch (Exception ex) {
            Logger.getLogger(StudentController.class.getName()).log(Level.SEVERE, null, ex);
            new Alert(Alert.AlertType.ERROR, "Unable to load the form. Exiting...").show();
        }
    }

    private void initTable() {
        tcFirstName.setCellValueFactory(person -> person.getValue().getFirstNameProperty());
        tcLastName.setCellValueFactory(person -> person.getValue().getLastNameProperty());
        tcYearOfStudy.setCellValueFactory(person -> person.getValue().getYearOfStudyProperty());
        tcEmail.setCellValueFactory(person -> person.getValue().getEmailProperty());
        tvStudents.setItems(students);
    }

    private void addIntegerMask(TextField tf) {
        UnaryOperator<TextFormatter.Change> integerFilter = change -> {
            String input = change.getText();
            if (input.matches("\\d*")) {
                return change;
            }
            return null;
        };
        // first we must convert integer to string, and then we apply filter
        tf.setTextFormatter(new TextFormatter<>(new IntegerStringConverter(), 0, integerFilter));
    }

    private void setupListeners() {
        tpContent.setOnMouseClicked(event -> {
            if (tpContent.getSelectionModel().getSelectedItem().equals(tabEdit) && !tabEdit.equals(previousTab)) {
                bindPerson(null);
            }
            System.out.println(previousTab);
            previousTab = tpContent.getSelectionModel().getSelectedItem();

        });
        students.addListener((ListChangeListener.Change<? extends StudentViewModel> change) -> {
            if (change.next()) {
                if (change.wasRemoved()) {
                    change.getRemoved().forEach(pvm -> {
                        try {
                            RepositoryFactory.getRepository().deleteStudent(pvm.getPerson());
                        } catch (Exception ex) {
                            Logger.getLogger(StudentController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                } else if (change.wasAdded()) {
                    change.getAddedSubList().forEach(pvm -> {
                        try {
                            int idPerson = RepositoryFactory.getRepository().addStudent(pvm.getPerson());
                            pvm.getPerson().setIDStudent(idPerson);
                        } catch (Exception ex) {
                            Logger.getLogger(StudentController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                }
            }
        });
    }

    @FXML
    private void delete(ActionEvent event) {
        if (tvStudents.getSelectionModel().getSelectedItem() != null) {
            students.remove(tvStudents.getSelectionModel().getSelectedItem());
        }
    }

    @FXML
    private void edit(ActionEvent event) {
        if (tvStudents.getSelectionModel().getSelectedItem() != null) {
            bindPerson(tvStudents.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEdit);
            previousTab = tabEdit;
        }
    }

    private void bindPerson(StudentViewModel viewModel) {
        resetForm();

        selectedStudentViewModel = viewModel != null ? viewModel : new StudentViewModel(null);
        tfFirstName.setText(selectedStudentViewModel.getFirstNameProperty().get());
        tfLastName.setText(selectedStudentViewModel.getLastNameProperty().get());
        tfYearOfStudy.setText(String.valueOf(selectedStudentViewModel.getYearOfStudyProperty().get()));
        tfEmail.setText(selectedStudentViewModel.getEmailProperty().get());
        ivPerson.setImage(selectedStudentViewModel.getPictureProperty().get() != null ? new Image(new ByteArrayInputStream(selectedStudentViewModel.getPictureProperty().get())) : new Image(new File("src/assets/no_image.png").toURI().toString()));
    }

    private void resetForm() {
        validationMap.values().forEach(lb -> lb.setVisible(false));
        lbIconError.setVisible(false);
    }

    @FXML
    private void uploadImage(ActionEvent event) {
        File file = FileUtils.uploadFileDialog(tfYearOfStudy.getScene().getWindow(), "jpg", "jpeg", "png");
        if (file != null) {
            Image image = new Image(file.toURI().toString());
            try {
                String ext = file.getName().substring(file.getName().lastIndexOf(".") + 1);
                selectedStudentViewModel.getPerson().setPicture(ImageUtils.imageToByteArray(image, ext));
                ivPerson.setImage(image);
            } catch (IOException ex) {
                Logger.getLogger(StudentController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

    @FXML
    private void commit(ActionEvent event) {
        if (formValid()) {
            selectedStudentViewModel.getPerson().setFirstName(tfFirstName.getText().trim());
            selectedStudentViewModel.getPerson().setLastName(tfLastName.getText().trim());
            selectedStudentViewModel.getPerson().setYearOfStudy(Integer.valueOf(tfYearOfStudy.getText().trim()));
            selectedStudentViewModel.getPerson().setEmail(tfEmail.getText().trim());
            if (selectedStudentViewModel.getPerson().getIDStudent()== 0) {
                students.add(selectedStudentViewModel);
            } else {
                try {
                    // we cannot listen to the upates
                    RepositoryFactory.getRepository().updateStudent(selectedStudentViewModel.getPerson());
                    tvStudents.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(StudentController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedStudentViewModel = null;
            tpContent.getSelectionModel().select(tabList);
            resetForm();
        }
    }

    private boolean formValid() {
        // discouraged but ok!
        final AtomicBoolean ok = new AtomicBoolean(true);
        validationMap.keySet().forEach(tf -> {
            if (tf.getText().trim().isEmpty() || tf.getId().contains("Email") && !ValidationUtils.isValidEmail(tf.getText().trim())) {
                validationMap.get(tf).setVisible(true);
                ok.set(false);
            } else {
                validationMap.get(tf).setVisible(false);
            }
        });

        if (selectedStudentViewModel.getPictureProperty().get() == null) {
            lbIconError.setVisible(true);
            ok.set(false);
        } else {
            lbIconError.setVisible(false);
        }
        return ok.get();
    }
    
}
