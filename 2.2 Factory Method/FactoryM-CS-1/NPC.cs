namespace FactoryM_CS_1
{
    abstract class NPC
    {
        public double HP{ get; set;}
        public double MaxHP { get; private set;}
        public string Name { get;  private set;}
        public bool isEnemy { get; set;}
        
        public NPC(string Name, double MaxHP, bool isEnemy)
        {
            this.Name = Name;
            this.MaxHP = MaxHP;
            this.HP = MaxHP;
            this.isEnemy = true;
        }
    }
}
