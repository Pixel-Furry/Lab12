//Jared Cook  -  Lab 12(extension of Lab 1)  -  12/5/2024


Console.WriteLine("Please enter a string (I will display the shifted string): ");
string userInput = Console.ReadLine();
Console.WriteLine("Now please use the arrow keys to change how decide how shifted you want: ");
int numToShiftBy = 0;
ConsoleKey inputFromUser = Console.ReadKey(true).Key;
while(inputFromUser != ConsoleKey.Enter) {
   if(inputFromUser == ConsoleKey.UpArrow) {
        numToShiftBy++;
    } else if (inputFromUser == ConsoleKey.DownArrow) {
        numToShiftBy--;
    } else {
        Console.Write("Not a valid input");
    }
    inputFromUser = Console.ReadKey(true).Key;
}
for(int i = 0; i < userInput.Length; i++) {
    Console.Write(Library.ShiftedCharacter(userInput[i], numToShiftBy));
}

public class Library {
public static int AsciiFromCharacter(char originalCharacter) {
    return (int) originalCharacter;
}

public static char CharacterFromAscii(int asciiValue) {
    return (char) asciiValue;
}

public static char ShiftedCharacter(char originalCharacter, int shiftInteger) {
        return CharacterFromAscii(WrapLetterPosition(LetterPosition(originalCharacter) + shiftInteger) + 'a');
}

public static int LetterPosition(char originalCharacter) {
        return (int) (originalCharacter - 97);
}

public static char WrapLetterPosition(int asciiValue) {
        return (char) (asciiValue % 26);
}
}

public class Tests() {
    [Fact]
    public void Test1() {
        Assert.Equal(Library.ShiftedCharacter('a', 3), 'd');
        Assert.Equal(Library.ShiftedCharacter('z', -3), 'w');
        Assert.Equal(Library.LetterPosition('a'), 0);
        Assert.Equal(Library.LetterPosition('b'), 1);
        Assert.Equal(Library.WrapLetterPosition(0), 0);
        Assert.Equal(Library.WrapLetterPosition(3), 3);
        Assert.Equal(Library.WrapLetterPosition(26), 0);
        Assert.Equal(Library.WrapLetterPosition(29), 3);
    }
}