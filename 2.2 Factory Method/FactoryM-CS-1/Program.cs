using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FactoryM_CS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var npcGenerator = new NPCFactory();
            var buchOfNPCs = Enumerable.Range(1,10)
                                    .Select(i => npcGenerator.GenerateRandomNPC())
                                    .ToList();
            buchOfNPCs.ForEach( npc => Console.WriteLine(npc));
        }
    }
}
