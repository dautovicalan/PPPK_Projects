/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.alan;

import com.alan.dao.RepositoryFactory;
import java.io.IOException;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 *
 * @author Alan
 */
public class StudentManagerApplication extends Application {
    
    
    private static Stage mainStage;
    
    @Override
    public void start(Stage primaryStage) throws IOException {

        Parent root = FXMLLoader.load(getClass().getResource("view/MainScreen.fxml"));        
        
        Scene scene = new Scene(root, 1200, 600);
        
        primaryStage.setTitle("Student, Profesor and Kolegij Manager!");
        primaryStage.setScene(scene);
        primaryStage.show();
        mainStage = primaryStage;
    }

    public static Stage getMainStage() {return mainStage;}
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }
    
    @Override
    public void stop() throws Exception {
        super.stop(); 
        RepositoryFactory.getRepository().release();
    }
    
}
