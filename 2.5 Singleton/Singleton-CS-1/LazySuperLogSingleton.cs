using System;
namespace Singleton_CS_1
{
    class LazySuperLogSingleton
    {
        private static readonly Lazy<LazySuperLogSingleton> _instance = new Lazy<LazySuperLogSingleton>(()=>new LazySuperLogSingleton());
        public static LazySuperLogSingleton Instance { get => _instance.Value;}
        private string _output = "Lazy Super Log is Sleeping...\n";
        public string Output{ get => _output;}
        private LazySuperLogSingleton() => _output += "Waking up Lazy Super Log...\n";
        public void AddLine(string text) => _output += $"{text}\n";
    }
}
