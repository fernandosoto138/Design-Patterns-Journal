namespace Singleton_CS_1
{
    class SuperLogSingleton
    {
        private static readonly SuperLogSingleton _instance = new SuperLogSingleton();
        public static SuperLogSingleton Instance{ get => _instance;}
        private string _output = "";
        public string Output{ get => _output;}
        private SuperLogSingleton() => _output += "Starting Super Log...\n";
        public void AddLine(string text) => _output += $"{text}\n";
    }
}
