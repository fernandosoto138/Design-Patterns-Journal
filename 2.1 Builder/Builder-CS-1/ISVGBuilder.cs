namespace Builder_CS_1
{
    interface ISVGBuilder
    { 
        ISVGElement root {get ;}
        
        ISVGBuilder AddElement(ISVGElement elem);
        ISVGElement BuildAll();
        
        void Clear();
    }

    
}
