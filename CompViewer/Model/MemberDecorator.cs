using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class MemberDecorator<T> : Member<T>
{
    protected Member<T> _member;

    /// <summary>
    /// Constructeur du Decorateur de la classe Membre
    /// </summary>
    /// <param name="member"></param>
    public MemberDecorator(Member<T> member)
    {
        this._member = member;
    }

    #region Methodes
    public override bool checkMember(string sLogin, string sPassword)
    {
        return this._member.checkMember(sLogin, sPassword);
    }

    public override bool connectToDb()
    {
        return this._member.connectToDb();
    }

    public override void closeDb()
    {
        this._member.closeDb(); 
    }
    public override bool addMember(Member<T> user)
    {
        return this._member.addMember(user);
    }
    public override string generateMD5(string password)
    {
        return this._member.generateMD5(password);
    }

    public override string GetMd5Hash(MD5 md5Hash, string input)
    {
        return this._member.GetMd5Hash(md5Hash, input);
    }

    public override bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
    {
        return this._member.VerifyMd5Hash(md5Hash, input, hash);
    }

    public override void Display()
    {
        this._member.Display();
    }
    #endregion 
}

