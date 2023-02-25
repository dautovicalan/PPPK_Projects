/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan.controller;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.StackPane;

/**
 * FXML Controller class
 *
 * @author Alan
 */
public class MainScreenController implements Initializable {

   @FXML
   private BorderPane mainPane;
   @FXML
   private Button btnStudent;
   @FXML
   private Button btnProfesor;
   @FXML
   private Button btnKolegij;
   
    
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        setupListeners();     
    }   

    private void setupListeners() {
        btnStudent.setOnAction((event) -> {
            try {
                AnchorPane pane = FXMLLoader.load(getClass().getResource("/com/alan/view/Student.fxml"));
                mainPane.setCenter(pane);
            } catch (IOException ex) {
                Logger.getLogger(MainScreenController.class.getName()).log(Level.SEVERE, null, ex);
            }                    
        });
        
        btnProfesor.setOnAction((event) -> {
            try {
                AnchorPane pane = FXMLLoader.load(getClass().getResource("/com/alan/view/Profesor.fxml"));
                mainPane.setCenter(pane);
            } catch (IOException ex) {
                Logger.getLogger(MainScreenController.class.getName()).log(Level.SEVERE, null, ex);
            }                    
        });
        btnKolegij.setOnAction((event) -> {
            try {
                AnchorPane pane = FXMLLoader.load(getClass().getResource("/com/alan/view/Kolegij.fxml"));
                mainPane.setCenter(pane);
            } catch (IOException ex) {
                Logger.getLogger(MainScreenController.class.getName()).log(Level.SEVERE, null, ex);
            }                    
        });
        
    }
    
}
