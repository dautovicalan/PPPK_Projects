/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.controller;

import com.alan.dao.RepositoryFactory;
import com.alan.model.Profesor;
import com.alan.viewmodel.KolegijViewModel;
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
import javafx.scene.control.ButtonType;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.TextFormatter;
import javafx.util.converter.IntegerStringConverter;

/**
 * FXML Controller class
 *
 * @author Alan
 */
public class KolegijController implements Initializable {
    
    private Map<TextField, Label> validationMap;

    private final ObservableList<KolegijViewModel> kolegijs = FXCollections.observableArrayList();

    private KolegijViewModel selectedKolegijViewModel;

    private Tab previousTab;

    @FXML
    private TabPane tpContent;
    @FXML
    private Tab tabEdit;
    @FXML
    private Tab tabList;
    @FXML
    private TableView<KolegijViewModel> tvKolegijs;
    @FXML
    private TableColumn<KolegijViewModel, Integer> tcIdKolegij;
    @FXML
    private TableColumn<KolegijViewModel, String> tcKolegijName, tcProfesorId;
    @FXML
    private TextField tfKolegijName;
    @FXML
    private ComboBox<Profesor> cbProfesors;
    @FXML
    private Label lbErrorKolegijName, lbErrorProfesors;

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
        validationMap = Stream.of(new AbstractMap.SimpleImmutableEntry<>(tfKolegijName, lbErrorKolegijName))
                .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
    }

    private void initPeople() {
        try {
            RepositoryFactory.getRepository().getKolegijs().forEach(kolegij -> kolegijs.add(new KolegijViewModel(kolegij)));
            cbProfesors.setItems(FXCollections
                .observableList(RepositoryFactory.getRepository().getProfesors()));
        } catch (Exception ex) {
            Logger.getLogger(KolegijController.class.getName()).log(Level.SEVERE, null, ex);
            new Alert(Alert.AlertType.ERROR, "Unable to load the form. Exiting...").show();
        }
    }

    private void initTable() {
        tcIdKolegij.setCellValueFactory(kolegij -> kolegij.getValue().getIdKolegijProperty().asObject());
        tcKolegijName.setCellValueFactory(kolegij -> kolegij.getValue().getKolegijNameProperty());
        tcProfesorId.setCellValueFactory(kolegij -> kolegij.getValue().getProfesorId());
        tvKolegijs.setItems(kolegijs);
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
                bindKolegij(null);
            }
            System.out.println(previousTab);
            previousTab = tpContent.getSelectionModel().getSelectedItem();

        });
        kolegijs.addListener((ListChangeListener.Change<? extends KolegijViewModel> change) -> {
            if (change.next()) {
                if (change.wasRemoved()) {
                    change.getRemoved().forEach(pvm -> {
                        try {
                            RepositoryFactory.getRepository().deleteKolegij(pvm.getKolegij());
                        } catch (Exception ex) {
                            Logger.getLogger(KolegijController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                } else if (change.wasAdded()) {
                    change.getAddedSubList().forEach(pvm -> {
                        try {
                            int idKolegij = RepositoryFactory.getRepository().addKolegij(pvm.getKolegij());
                            pvm.getKolegij().setIDKolegij(idKolegij);
                        } catch (Exception ex) {
                            Logger.getLogger(KolegijController.class.getName()).log(Level.SEVERE, null, ex);
                        }
                    });
                }
            }
        });
    }

    @FXML
    private void delete(ActionEvent event) {
        if (tvKolegijs.getSelectionModel().getSelectedItem() != null) {
            kolegijs.remove(tvKolegijs.getSelectionModel().getSelectedItem());
        }
    }

    @FXML
    private void edit(ActionEvent event) {
        if (tvKolegijs.getSelectionModel().getSelectedItem() != null) {
            bindKolegij(tvKolegijs.getSelectionModel().getSelectedItem());
            tpContent.getSelectionModel().select(tabEdit);
            previousTab = tabEdit;
        }
    }

    private void bindKolegij(KolegijViewModel viewModel) {
        resetForm();

        selectedKolegijViewModel = viewModel != null ? viewModel : new KolegijViewModel(null);
        tfKolegijName.setText(selectedKolegijViewModel.getKolegijNameProperty().get()); 
        cbProfesors.getSelectionModel().select(selectedKolegijViewModel.getKolegij().getProfesorID());
    }

    private void resetForm() {
        validationMap.values().forEach(lb -> lb.setVisible(false));        
    }

    @FXML
    private void commit(ActionEvent event) {
        if (formValid()) {
            selectedKolegijViewModel.getKolegij().setKolegijName(tfKolegijName.getText().trim());
            selectedKolegijViewModel.getKolegij().setProfesorID(cbProfesors.getSelectionModel().getSelectedItem());
            if (selectedKolegijViewModel.getKolegij().getIDKolegij()== 0) {
                kolegijs.add(selectedKolegijViewModel);
            } else {
                try {
                    // we cannot listen to the upates
                    RepositoryFactory.getRepository().updateKolegij(selectedKolegijViewModel.getKolegij());
                    tvKolegijs.refresh();
                } catch (Exception ex) {
                    Logger.getLogger(KolegijController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            selectedKolegijViewModel = null;
            tpContent.getSelectionModel().select(tabList);
            resetForm();
        }
    }

    private boolean formValid() {
        // discouraged but ok!
        final AtomicBoolean ok = new AtomicBoolean(true);
        validationMap.keySet().forEach(tf -> {
            if (tf.getText().trim().isEmpty()) {
                validationMap.get(tf).setVisible(true);
                ok.set(false);
            } else {
                validationMap.get(tf).setVisible(false);
            }
        });
        
        if (cbProfesors.getSelectionModel().getSelectedItem() == null) {
            ok.set(false);
            new Alert(Alert.AlertType.ERROR, "Please select profesor", ButtonType.OK).show();
        } else {
            ok.set(true);
        }        
        return ok.get();
    }
    
}
