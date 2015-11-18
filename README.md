# eqgenerate
###simple equation generator game. The scope is to calculate and match the correct answer for random generated equations. 
====

- To run, go, in the console, to */TestConsoleApp/bin/Debug*
- run `TestConsoleApp x` where x is the level (int) you choose for the nr of elements in the eq

You can also run it directly in VS and it defaults to a level value of "3".

### Models

The models for the equation are:
- **EqElement** (abstract class)
- **EqNumber** (Inherits EqElement, contains a simple int number)
- **Eq** (Ingerits EqElement, contains an equation, composed of 2 EqElement-inherited objects and a type of operation)

### Eq generator

Responsible for generating equations is **EqGenerator**. It generates 4 types of operation between the elements: `+`,`-`,`*`,`/`. Numbers in the equations range in the interval [1,100], integer. The result of the equations are always positive and integers.
The Equation can be shown as either in a one-line tree view or in a simplified view (eliminating unnecesary parentheses).

### Tree structure examination 

### Limitations

To provide with always integer results, the `/` operation is introduced whenever the 2 elements of an equation can divide with an integer result. 
