using System;

namespace Prototype_CS_1
{
    [Serializable]
    public class HugeClass
    {
        public string Text { get; set; } = "I'm HUGE!!!";

        public override string ToString() => Text;

    }
}
