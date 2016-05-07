using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithString
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                string result = "";

                Console.Title = "Work With String";
                Console.WriteLine("Welcome to myApp");
                Console.WriteLine(Environment.NewLine + new string('_', 30)+Environment.NewLine);

                // Input block
                Console.Write("Input value to tranform ---> ");
                string statement = Console.ReadLine();
                result = PerformString(statement);

                // Output
                Console.WriteLine("New statement ---> {0}",result);
                Console.WriteLine(Environment.NewLine+new string('_',30));

                // User next action dialog
                Console.WriteLine("For next operation press any key ... for exit press Escape");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
            
        }

        /// <summary>
        /// Revers text block seporated by punctuation and whiteSpaceBlock
        /// </summary>
        /// <param name="statement">string statement</param>
        /// <returns>string with reversed letters blocks</returns>
        private static string PerformString(string statement) {
            bool substringTarget = false;

            // Work loop
            for (int i = 0, startPos = 0, substringLength = 0; i <= statement.Length; i++){
                // Find next letter block
                if (i < statement.Length && char.IsLetter(statement[i])){
                    if (substringTarget == false){
                        startPos = i;
                        // Do new block mark
                        substringTarget = true;
                    }

                    substringLength++;
                }
                else {
                    // if statement's lenght more than 0....
                    if (substringLength != 0)
                    {
                        // Substring target block and revers
                        char[] subStatement = statement.Substring(startPos,
                            substringLength).ToCharArray();
                        Array.Reverse(subStatement);

                        // Replace modificated block
                        statement = statement.Replace(statement.Substring(startPos, substringLength),
                            new string(subStatement));

                        // Clear target block parametrs
                        substringTarget = false; startPos = 0; substringLength = 0;
                    }
                }
            }

            return statement;
        }
    }
}
