using System;

namespace UltimateTicTacToe; 

public class Cell {
    private char Owner { get; set; }

    private void SetOwner(char value) {
        if (Owner == ' ') {
            Owner = value;
        }
    }
    
    public Cell() {
        SetOwner(' ');
    }
    
    public bool IsSet(){
        return Owner != ' ';
    }
}