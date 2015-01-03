using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Admin<T> : MemberDecorator<T>
{
    /// <summary>
    /// Constructuer contenant les valeurs de la class Member
    /// </summary>
    /// <param name="member"></param>
    public Admin(Member<T> member):base(member)
    { 
        
    }

    /// <summary>
    /// Fonction permettant d'ajout un admin
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    public override bool addMember(Member<T> member)
    {
        return base.addMember(member);
    }

    /// <summary>
    /// Fonction permettant de vérifier si un admin existe 
    /// </summary>
    /// <param name="sLogin"></param>
    /// <param name="sPassword"></param>
    /// <returns></returns>
    public override bool checkMember(string sLogin, string sPassword)
    {
        return base.checkMember(sLogin,  sPassword);
    }

    /// <summary>
    /// Fonction permettant d'afficher les informations de l'admin
    /// </summary>
    public override void Display()
    {
        base._member.Display();
    }

   
}

