namespace AdvancedCSharp {

    public class NamedOptionalArgs : ITutorial {

        public void Run() {
            var helper = new Helper();
            
            helper.Process("Hello", false, new int[] { 1, 1, 2, 3, 5 });

            helper.NewProcess("Hello");
            helper.NewProcess(moreData: new int[] { 1, 1, 2, 3, 5 });
            helper.NewProcess("Hello", true, 1, 1, 2, 3, 5);
        }

        public class Helper {

            #region Old Way

            public void Process(string data) {
                Process(data, false);
            }

            public void Process(string data, bool ignoreWS) {
                Process(data, ignoreWS, null);
            }

            public void Process(string data, bool ignoreWS, int[] moreData) {
                // Actual work done here
            }

            #endregion

            #region New Way

            public void NewProcess(string data = null, bool ignoreWS = false, params int[] moreData) {
            }
            
            #endregion
        }
    }
}