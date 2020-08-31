using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type 'menu' at any time";
    string[] level1Passwords = {"bribe", "payment", "collateral", "coverup", "judgegate"};
    string[] level2Passwords = {"kraken", "diamond", "billionaire", "corruption", "sociolinguistics"};
    string[] level3Passwords = {"heiarchy", "symbolism"};

    //Game State
    string password;
    string anagram;
    int level;
    int index;
    int tokens = 2;
    int randomPassword;
    enum Screen {Title, MainMenu, Puzzle, Win};
    Screen currentScreen;

    
    
    // Start is called before the first frame update
    void Start() {
        ShowTitleScreen();
        // ShowMainMenu();
    }

    void ShowTitleScreen() {
        Terminal.WriteLine(@"

         ╭━━━┳━━┳━━━┳╮╱╭┳━━━┳━━━┳━╮╱╭╮
         ┃╭━╮┣┫┣┫╭━╮┃┃╱┃┃╭━╮┃╭━╮┃┃╰╮┃┃
         ┃┃╱╰╯┃┃┃╰━╯┃╰━╯┃╰━╯┃┃╱┃┃╭╮╰╯┃
         ┃┃╱╭╮┃┃┃╭━━┫╭━╮┃╭╮╭┫┃╱┃┃┃╰╮┃┃
         ┃╰━╯┣┫┣┫┃╱╱┃┃╱┃┃┃┃╰┫╰━╯┃┃╱┃┃┃
         ╰━━━┻━━┻╯╱╱╰╯╱╰┻╯╰━┻━━━┻╯╱╰━╯

"
            );
            Terminal.WriteLine("            Enter " + tokens + " tokens to play");
    }

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Accessing central mainframe...");
        Terminal.WriteLine("Access Granted");
        Terminal.WriteLine("Eliminate all security threats");
        Terminal.WriteLine("To hack the Constable's Office, Press 1");
        Terminal.WriteLine("To hack the Judge's Office, Press 2");
        Terminal.WriteLine("To hack the Parliments's Office, Press 3");

    }

    void OnUserInput (string input)
    {
        if (input == "menu") {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.Title) {
            InsertTokens(input);
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Puzzle) {
            CheckPassword(input, password);
        }
    }

    void InsertTokens(string input) {
        tokens--;
        if (tokens == 0){
            ShowMainMenu();
        }
        else {
            Terminal.ClearScreen();
            ShowTitleScreen();
        }
    }

    void AskForPassword(){
        currentScreen = Screen.Puzzle;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void SetRandomPassword(){
        switch(level){
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Terminal.WriteLine("Error, type 'menu' to return");
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void RunMainMenu(string input) {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber){
            level = int.Parse(input); //turn user input into to integer
            AskForPassword();
        }
        else {
            Terminal.ClearScreen();
            Terminal.WriteLine("Input not recognized");
        }
    }

    void CheckPassword(string input, string password) {
        if (input == password) {
            DisplayWinScreen();
        }
        else if ( input == "menu") {
            ShowMainMenu();
        }
        else {
            Terminal.WriteLine("I'm sorry that is not the correct password");
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        ShowLevelReward();
    }

    void ShowLevelReward(){
        switch (level){
            case 1:
            Terminal.WriteLine("You have discovered the first clue....");
            Terminal.WriteLine("A Key!");
            Terminal.WriteLine(@"
  _____________ 
 / o  ___  _  _|
 \___/   || ||        
"
            );
            break;
            case 2:
            Terminal.WriteLine("You have found the Floppy Disk!");
            Terminal.WriteLine(@"
  _ _____
 |_|_____|
 |   _   | 
 |  (_)  |
 |_______|
"           );
            break;
            case 3:
            Terminal.WriteLine("You have found a pile of money!");
            Terminal.WriteLine(@"
   _____________
  / $ / $ / $ /$|
 / $ / $ / $ /$/|
 =============///
 =============//
 =============/
"           );
            break;
        }
        // Terminal.WriteLine("Congratulations, you win");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
