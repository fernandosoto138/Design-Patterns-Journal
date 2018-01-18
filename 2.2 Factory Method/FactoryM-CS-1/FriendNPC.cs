namespace FactoryM_CS_1
{
    //Concrete Product
    class FriendNPC : NPC
    {
        public FriendNPC(string Name, double MaxHP)
            :base(Name,MaxHP,false)
        {
        }
        public override string ToString() => $"Hello Friend, I'm {base.Name} and I have {base.HP}HP!";
    }
}
