using System;
using static System.Console;

namespace AdvancedCSharp {

    public class DefaultInterfaceMembers : ITutorial {

        public void Run() {
            ILogger logger = new ConsoleLogger();
            logger.Log(new InvalidOperationException("This is not allowed!"));
        }

        public interface ILogger {
            void Log(LogLevel level, string message);

            // new method with default behavior
            void Log(Exception ex) => Log(LogLevel.Error, ex.ToString());
        }


        public class ConsoleLogger : ILogger {
            public void Log(LogLevel level, string message) {
                var defaultColor = ForegroundColor;
                switch (level) {
                    case LogLevel.Error:
                        ForegroundColor = ConsoleColor.Red;
                        break;
                    case LogLevel.Warning:
                        ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                }
                WriteLine(message);
                ForegroundColor = defaultColor;
            }
        }

        public enum LogLevel {
            Info,
            Warning,
            Error
        }
    }
}