using System;

namespace UltimateTicTacToe; 

public class Cell {
    private char Owner { get; set; }

    public void SetOwner(char value) {
        if (Owner == ' ') {
            Owner = value;
        }
    }
    
    public Cell() {
        Owner = ' ';
    }
    
    public bool IsSet(){
        return Owner != ' ';
    }
}