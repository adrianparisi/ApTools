namespace SomeTools.Tests.Reflection
{
    class MyFakeClass
    {
        private MyFakeClass() { }
        private MyFakeClass(int intiger) { }
        public MyFakeClass(string text) { }


        private int MyMethod(bool boolean)
        {
            return 1;
        }

        private static int MyMethod(string text)
        {
            return 2;
        }

        private int MyMethod(bool boolean, string text)
        {
            return 3;
        }
    }
}
