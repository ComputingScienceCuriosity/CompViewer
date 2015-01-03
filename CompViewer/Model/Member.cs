using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public abstract class Member<T>
{
    #region Properties 
    public int Id
	{
		get;
		set;
	}

    public string Fname
    {
        get;
        set;
    }

    public string Lname
    {
        get;
        set;
    }

    public string Login
    {
        get;
        set;
    }

    public string Password
    {
        get;
        set;
    }

    public string Email
    {
        get;
        set;
    }

    public string Function
	{
		get;
		set;
	}
    #endregion 

    /// <summary>
    /// Ouvre une connexion à la base de données 
    /// </summary>
    /// <returns></returns>
    public abstract bool connectToDb();

    /// <summary>
    /// Ferme de la connexion courante
    /// </summary>
    public abstract void closeDb();

    /// <summary>
    /// Vérifie si un utilisateur existe ou non
    /// </summary>
    /// <param name="sLogin"></param>
    /// <param name="sPassword"></param>
    /// <returns></returns>
    public abstract bool checkMember(string sLogin, string sPassword);

    /// <summary>
    /// Ajoute un nouveau membre
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public abstract bool addMember(Member<T> user);

    /// <summary>
    /// Généres un Hash MD5
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public abstract string generateMD5(string password);
    public abstract string GetMd5Hash(MD5 md5Hash, string input);
    public abstract bool VerifyMd5Hash(MD5 md5Hash, string input, string hash);

    /// <summary>
    /// Affiches les informations du membre
    /// </summary>
    public abstract void Display();
}

