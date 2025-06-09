using System;

namespace A2Layan
{
    public class Game
    {
        private Random random;
        private int attemptCount;
        private const int MaxAttempts = 3;

        // 1) Private backing fields for each die, initialized to 0:
        private int die1 = 0;
        private int die2 = 0;
        private int die3 = 0;

        // 2) Public properties with getters and setters for each die:
        public int Die1
        {
            get { return die1; }
            private set { die1 = value; }
        }

        public int Die2
        {
            get { return die2; }
            private set { die2 = value; }
        }

        public int Die3
        {
            get { return die3; }
            private set { die3 = value; }
        }

        public Game()
        {
            random = new Random();
            attemptCount = 0;
        }
         

        /// <summary>
        /// Rolls either two or three dice and increments attemptCount (up to MaxAttempts).
        /// Stores the results in the private fields via the public properties.
        /// </summary>
        public void RollDice(bool threeDiceMode)
        {
            if (attemptCount < MaxAttempts)
                attemptCount++;

            Die1 = random.Next(1, 7);
            Die2 = random.Next(1, 7);

            // Use an if/else to set Die3
            if (threeDiceMode)
                Die3 = random.Next(1, 7);
            else
                Die3 = 0;
        }

        /// <summary>
        /// Checks win condition: sum == 7 or 11 (within allowed attempts).
        /// If no win after MaxAttempts, returns "Computer wins!". Otherwise, prompts to try again.
        /// </summary>
  
        public string CheckWinner(int sum, bool threeDiceMode)
        {
            if (threeDiceMode)
            {
                // Three‐dice mode: win on 11 or 18
                if ((sum == 11 || sum == 18) && attemptCount <= MaxAttempts)
                    return $" Congratulation , You win! You rolled {sum} on attempt {attemptCount}.";

                if (attemptCount >= MaxAttempts)
                    return "Computer win the game!";

                return $" Try again! Number of Attempt {attemptCount} .";
            }
            else
                // Two‐dice mode: win on 7 or 11
                if ((sum == 7 || sum == 11) && attemptCount <= MaxAttempts)
                    return $" Congratulation , You win! You rolled {sum} on attempt {attemptCount}.";

                if (attemptCount >= MaxAttempts)
                    return "Computer win the game!";

                return $"  Try again! Number of  Attempt {attemptCount}.";
            }
        

        /// <summary>
        /// Resets attemptCount and clears the dice values back to 0.
        /// </summary>
        public void ResetGame()
        {
            attemptCount = 0;
            Die1 = 0;
            Die2 = 0;
            Die3 = 0;
        }
    }
}
