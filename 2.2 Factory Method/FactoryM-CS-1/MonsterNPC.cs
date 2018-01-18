namespace FactoryM_CS_1
{
    class MonsterNPC : NPC
    {
        public MonsterNPC(string Name, double MaxHP)
            :base(Name,MaxHP,true)
        {
        }
        public override string ToString() => $"Rraarrw! I'm the temible {Name} and I have {HP}HP!";
    }
}
