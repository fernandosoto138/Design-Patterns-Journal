using System;

namespace FactoryM_CS_1
{
    //Concrete Factory
    class NPCFactory : INPCFactory
    {
        string[] MonsterNames = new string[]{"Ronald McDonald","Destructor","Donald Trump"};
        string[] FriendNames = new string[]{"Legionary", "Harry Potter", "Snowman"};
        static Random rnd = new Random();
        public NPC GenerateRandomNPC()
        {
                var hp = rnd.Next(1,9999);
                var name = rnd.Next();
                if((rnd.Next(0,1000) % 2) == 1)
                    return new FriendNPC(FriendNames[name % 3],hp);
                return new MonsterNPC(MonsterNames[name % 3],hp);    
                
        }
    }
}
