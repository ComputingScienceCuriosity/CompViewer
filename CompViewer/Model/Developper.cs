using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Developper<T> : MemberDecorator<T>
{
    /// <summary>
    /// Constructeur contenant les valeurs de la classe Member
    /// </summary>
    /// <param name="member"></param>
    public Developper(Member<T> member)
        : base(member)
    { 
    }
}

