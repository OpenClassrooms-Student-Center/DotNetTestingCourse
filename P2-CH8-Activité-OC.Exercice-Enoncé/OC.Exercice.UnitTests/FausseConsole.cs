using System.Text;

namespace OC.Exercice.UnitTests
{
    public class FausseConsole : IConsole
    {
        public StringBuilder StringBuilder = new StringBuilder();

        public void Ecrire(string message)
        {
            StringBuilder.Append(message);
        }

        public void EcrireLigne(string message)
        {
            StringBuilder.AppendLine(message);
        }
    }
}
