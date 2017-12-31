using System.Collections.Generic;

namespace Builder_CS_1
{
    /// <summary>
    /// Interface for the SVGBuilderItems 
    /// </summary>
    interface ISVGElement
    {
        string TagName { get; }   
        string Properties {get;}
        List<ISVGElement> Elements { get;}

        ISVGElement AddProperty(string key, string value);
        ISVGElement AddElement(ISVGElement Element);

        string IndentedToString(int indent);
    }
}
