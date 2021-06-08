using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class InstructionsInfo : GameInstructions
    {
        //Base class constructor
        public InstructionsInfo()
            : base()
        {
        }

        public string GetPlayerInstruction (bool havePlayerInstruction) //Represents true or false value for text
        {
            if (havePlayerInstruction)
            {
                //If true then show display the enjoy text
                return "Enjoy!"; 
            }
            else
            {
                //If false then displau the no help text
                return "";
            }
        }
    }
}



