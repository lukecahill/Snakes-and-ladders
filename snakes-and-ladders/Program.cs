using System;

namespace snakes_and_ladders {
    class Program {
        /// <summary>
        /// Main class instantiates a Random object for use generating a random number between 1 and 6. Sets a const board limit of 25 squares, sets the default roll number and position. 
        /// All then run inside a while loop, calling relevant funtions when required.
        /// When the user wins then it will then print the congratulatory message.
        /// If the user goes over the board limit, the position resets to the current postiion - 25.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            Random rand = new Random();
            const int boardLimit = 25;
            int position = 0, rollNumber = 0;

            while (position <= boardLimit) {
                rollNumber++;
                PrintPositions(rollNumber, position);
                Console.ReadKey(true);

                position = RollDice(rand, position);
                position = CheckPosition(position);

                if (position == boardLimit) {
                    Console.WriteLine("Congratulations you won!");
                    break;
                }

                if (position > boardLimit) {
                    position -= boardLimit;
                    Console.WriteLine("You went over the board limit! Restarting from " + position);
                }
            }
            Console.Read();
        }

        /// <summary>
        /// Used to simulate a dice roll
        /// </summary>
        /// <param name="rand">Random object used to get a random number</param>
        /// <param name="position">Integer of current position on the board</param>
        /// <returns>Integer of the new position after dice roll</returns>
        static int RollDice(Random rand, int position) {
            var roll = rand.Next(1, 7);
            Console.WriteLine($"\nRoll: {roll}");
            position += roll;
            Console.WriteLine($"After roll: {position}");
            return position;
        }

        /// <summary>
        /// Print the current roll number, position, and then prompts the user to press a key to roll the dice.
        /// </summary>
        /// <param name="rollNumber"></param>
        /// <param name="position"></param>
        static void PrintPositions(int rollNumber, int position) {
            Console.WriteLine($"Roll number: {rollNumber}");
            Console.WriteLine($"Current position: {position}");
            Console.WriteLine("Press a key to roll the dice!");
        }

        /// <summary>
        /// Used to check if the current position is a 'tile' with a snake, or ladder on and then modifies the position appropriately. Uses a switch statement to determine this.
        /// </summary>
        /// <param name="position">Integer of the current position</param>
        /// <returns>Integer of the new positon</returns>
        static int CheckPosition(int position) {
            switch (position) { // More can be added easily if required.
                case 3:
                    position += 4;    // goes to 7
                    Console.WriteLine($"You went up a ladder to {position}");
                    break;
                case 6:
                    position += 4;    // goes to 10
                    Console.WriteLine($"You went up a ladder to {position}");
                    break;
                case 20:
                    position -= 4;    // goes to 16
                    Console.WriteLine($"You went down a snake to {position}");
                    break;
                case 15:
                    position -= 6;    // goes to 9
                    Console.WriteLine($"You went down a snake to {position}");
                    break;
                case 19:
                    position += 2;    // goes to 21
                    Console.WriteLine($"You went up a ladder to {position}");
                    break;
                default:
                    break;
            }
            return position;
        }
    }
}
