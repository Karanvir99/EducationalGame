using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class GameInstructions
    {
        private string InstructionsString;

        public GameInstructions()
        {
            InstructionsString = "Instructions:" + " "; //Start of the message box information
        }

        public string RecieveInstruction (string recieveInformation)
        {
            return InstructionsString + recieveInformation; //Return instructions and recieves message box information
        }
    }
}

