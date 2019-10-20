using System;
using System.Runtime.CompilerServices;

namespace AdvancedCSharp {

    public class CallerInfo : ITutorial {

        public void Run() {
            Helper.SaveEntity(new Company());
        }

        public class Helper {

            public static void SaveEntity<T>(T entity) {
                Log("Entity saved");
            }

            public static void Log(
                string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0
            ) {
                var msg = string.Format(
                    "Message: {0}, Member: {1}, File: {2}, Line: {3}",
                    message, memberName, sourceFilePath, sourceLineNumber
                );
                Console.WriteLine(msg);
            }
        }

        public class Company {
            public int Id { get; set; }
        }
    }
}