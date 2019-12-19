# Gravity Surge

A Game Prototype For Game Development Patterns Final Project.

## Project Group
Cem Hosgecin, Hamza Rashad, Md Kudrat-E Khuda, Milan Mucka.

## Development Patterns
* Command
* Bytecode
* Singleton
* Service Locator

## Pattern Implementation

### Command
Command development pattern used in the InputHandler script to maintain a dynamically changeable input callback allocation. In the game, there are only two inputs (left and right mouse click) available to register a command. The game prototype utilizes those inputs with a movement trigger command.

### Singleton
There are a lot of singleton modules/classes in the project such as PlayerLogic bytecode interpreter, AudioLocator service locator and InputHandler classes.

### Bytecode
Bytecode development pattern used in the PlayerLogic bytecode interpreter class. The interpreter class receives bytecode as a function parameter and interprets it to a meaningful data for the other classes to use it. There are four instructors (literal, barrier collision, action trigger and gravity change) to bytecode interpreter class to understand and interpret.

### Service Locator
Service locator used in AudioLocator class. The class provided with an AudioService which handles related audio. AudioService loads some audio files and those audio files can be played with a simple play() call with the index number of the target audio.

## Game Instructions
Game's only objective is to survive as much as possible with avoiding obtacles to push the player avatar down out of the screen. Players avoid obstacles by clicking left and right mouse button. If players click left button, player avatar launches itself to the right. If players click right button, player avatar launches itself to the left. There is also a charge mechanic in the game. That means the longer you hold the mouse click, the powerful your launches get.
