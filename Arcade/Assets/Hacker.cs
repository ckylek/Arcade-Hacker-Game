using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;
    enum Screen {MainMenu, Puzzle, Win};
    Screen currentScreen;
    
    // Start is called before the first frame update
    void Start() {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Accessing central mainframe...");
        Terminal.WriteLine("Access Granted");
        Terminal.WriteLine("Scanning nodes for vulnerabilities...");
        Terminal.WriteLine("Scan Complete.");
        Terminal.WriteLine("3 critical threats identified.");
        Terminal.WriteLine("Eliminate all security threats");
        Terminal.WriteLine("To hack the Constable's Office, Press 1");
        Terminal.WriteLine("To hack the Judge's Office, Press 2");
    }

    void OnUserInput (string input)
    {
        if (input == "menu") {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
    }

    void StartGame(int level){
        currentScreen = Screen.Puzzle;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have selected level " + level);
        Terminal.WriteLine("You have accessed the Judge's Personal Records");
    }
    void RunMainMenu(string input) {
        if(input == "1"){
            level = 1;
            StartGame(level);
        }
        else if (input == "2"){
            level = 2;
            StartGame(level);
        }
        else {
            Terminal.ClearScreen();
            Terminal.WriteLine("Input not recognized");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
