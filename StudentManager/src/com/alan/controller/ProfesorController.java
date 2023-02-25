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
import com.alan.viewmodel.ProfesorViewModel;
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
public class ProfesorController implements Initializable {
    
    private Map<TextField, Label> validationMap;

    private final ObservableList<ProfesorViewModel> profesors = FXCollections.observableArrayList();

    private ProfesorViewModel selectedProfesorViewModel;

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
    private TableView<ProfesorViewModel> tvProfesors;
    @FXML
    private TableColumn<ProfesorViewModel, String> tcFirstName, tcLastName, tcEmail;
    @FXML
    private TextField tfFirstName, tfLastName, tfEmail;
    @FXML
    private Label lbFirstNameError, lbLastNameError, lbEmailError, lbIconError;

    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        initValidation();
        initPeople();
        initTable();        
        setupListeners();
    }

    private void initValidation() {
        validationMap = Stream.of(new AbstractMap.SimpleImmutableEntry<>(tfFirstName, lbFirstNameError),
                new AbstractMap.SimpleImmutableEntry<>(tfLastName, lbLastNameError),                
                new AbstractMap.SimpleImmutableEntry<>(tfEmail, lbEmailError))
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initPeople() {
        try {
            RepositoryFactory.getRepository().getProfesors().forEach(profesor -> profesors.add(new ProfesorViewModel(profesor)));
        } catch (Exception ex) {
            Logger.getLogger(ProfesorController.class.getName()).log(Level.SEVERE, null, ex);
            new Alert(Alert.AlertType.ERROR, "Unable to load the form. Exiting...").show();
        }
    }

    private void initTable() {
        tcFirstName.setCellValueFactory(person -> person.getValue().getFirstNameProperty());
        tcLastName.setCellValueFactory(person -> person.getValue().getLastNameProperty());        
        tcEmail.setCellValueFactory(person -> person.getValue().getEmailProperty());
        tvProfesors.setItems(profesors);
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
        profesors.addListener((ListChangeListener.Change<? extends ProfesorViewModel> change) -> {
            if (change.next()) {
                if (change.wasRemoved()) {
                    change.getRemoved().forEach(pvm -> {
                        try {
                            RepositoryFactory.getRepository().deleteProfesor(pvm.getProfesor());
                        } catch (Exception ex) {
                            Logger.getLogger(ProfesorController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                } else if (change.wasAdded()) {
                    change.getAddedSubList().forEach(pvm -> {
                        try {
                            int idPerson = RepositoryFactory.getRepository().addProfesor(pvm.getProfesor());
                            pvm.getProfesor().setIDProfesor(idPerson);
                        } catch (Exception ex) {
                            Logger.getLogger(ProfesorController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                }
            }
        });
    }

    @FXML
    private void delete(ActionEvent event) {
        if (tvProfesors.getSelectionModel().getSelectedItem() != null) {
            profesors.remove(tvProfesors.getSelectionModel().getSelectedItem());
        }
    }

    @FXML
    private void edit(ActionEvent event) {
        if (tvProfesors.getSelectionModel().getSelectedItem() != null) {
            bindPerson(tvProfesors.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEdit);
            previousTab = tabEdit;
        }
    }

    private void bindPerson(ProfesorViewModel viewModel) {
        resetForm();

        selectedProfesorViewModel = viewModel != null ? viewModel : new ProfesorViewModel(null);
        tfFirstName.setText(selectedProfesorViewModel.getFirstNameProperty().get());
        tfLastName.setText(selectedProfesorViewModel.getLastNameProperty().get());        
        tfEmail.setText(selectedProfesorViewModel.getEmailProperty().get());
        ivPerson.setImage(selectedProfesorViewModel.getPictureProperty().get() != null ? new Image(new ByteArrayInputStream(selectedProfesorViewModel.getPictureProperty().get())) : new Image(new File("src/assets/no_image.png").toURI().toString()));
    }

    private void resetForm() {
        validationMap.values().forEach(lb -> lb.setVisible(false));
        lbIconError.setVisible(false);
    }

    @FXML
    private void uploadImage(ActionEvent event) {
        File file = FileUtils.uploadFileDialog(tfFirstName.getScene().getWindow(), "jpg", "jpeg", "png");
        if (file != null) {
            Image image = new Image(file.toURI().toString());
            try {
                String ext = file.getName().substring(file.getName().lastIndexOf(".") + 1);
                selectedProfesorViewModel.getProfesor().setPicture(ImageUtils.imageToByteArray(image, ext));
                ivPerson.setImage(image);
            } catch (IOException ex) {
                Logger.getLogger(ProfesorController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

    @FXML
    private void commit(ActionEvent event) {
        if (formValid()) {
            selectedProfesorViewModel.getProfesor().setFirstName(tfFirstName.getText().trim());
            selectedProfesorViewModel.getProfesor().setLastName(tfLastName.getText().trim());            
            selectedProfesorViewModel.getProfesor().setEmail(tfEmail.getText().trim());
            if (selectedProfesorViewModel.getProfesor().getIDProfesor()== 0) {
                profesors.add(selectedProfesorViewModel);
            } else {
                try {
                    // we cannot listen to the upates
                    RepositoryFactory.getRepository().updateProfesor(selectedProfesorViewModel.getProfesor());
                    tvProfesors.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(ProfesorController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedProfesorViewModel = null;
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

        if (selectedProfesorViewModel.getPictureProperty().get() == null) {
            lbIconError.setVisible(true);
            ok.set(false);
        } else {
            lbIconError.setVisible(false);
        }
        return ok.get();
    }
    
}
