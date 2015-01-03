using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;


public class MemberConcrete<T> : Member<T>
{
    #region Properties
   
    #endregion 

    public MemberConcrete()
    { }

    /// <summary>
    /// Constructeur qui permet de créer un utilisateur
    /// </summary>
    /// <param name="id"></param>
    /// <param name="function"></param>
    /// <param name="fname"></param>
    /// <param name="lname"></param>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="email"></param>
    public MemberConcrete(int id, string function, string fname, string lname, string login, string password, string email)
    {
       /* base.Id       = (int)   id;
        base.Function = (string)function;
        base.Fname    = (string)fname;
        base.Lname    = (string)lname;
        base.Login    = (string)login;
        base.Password = (string)generateMD5(password);
        base.Email    = (string)email;*/
    }

    #region Methodes

    public override bool connectToDb()
    {
        return SQLsharp<T>.Instance.connectToDB("localhost", "root", "", "dotnetdb");
    }

    public override void closeDb()
    {
        SQLsharp<T>.Instance.closeConnection();
    }

    /// <summary>
    /// Vérifie si le membre existe dans la base de données
    /// </summary>
    /// <param name="Member"></param>
    /// <returns> bool </returns>
    public override bool checkMember(string sLogin, string sPassword)
    {
        if (!connectToDb()) return false;

        Dictionary<string, T> dect = new Dictionary<string, T>();

        string _Login = sLogin;
        string _Pass  = generateMD5(sPassword);
        //string _Table = (Function.Equals("admin")) ? "admin" : "Member";
        string _Table = "admin";

        dect.Add("@Login", (T)Convert.ChangeType(_Login, typeof(string)));
        dect.Add("@pass",  (T)Convert.ChangeType(_Pass,  typeof(string)));

        string req = "SELECT login, pass FROM " + _Table + " WHERE (login = @Login AND pass = @pass)";
       
        // TODO: revoir le code de la fonction!!
        bool res = SQLsharp<T>.Instance.ExecDataReader(req, dect);
        closeDb();

        return res;
    }

    /// <summary>
    /// Ajoutes un utilisateur dans la base de données 
    /// </summary>
    /// <param name="Member"></param>
    /// <returns> bool </returns>
    public override bool addMember(Member<T> Member)
    {
        if (!connectToDb()) return false;

        string _Table = (Function.Equals("admin")) ? "admin" : "Member";
        string req = "INSERT INTO " + _Table + " (fname ,lname ,login ,pass ,email ,function) VALUES (@Fname,@Lname,@Login,@Password,@Email,@Function)";

        Dictionary<string, T> dect = new Dictionary<string, T>();
   
        string _Fname = Fname;
        string _Lname = Lname;
        string _Login = Login;
        string _Pass  = Password;
        string _Email = Email;
        string _Funct = Function;

        dect.Add("@Fname",      (T)Convert.ChangeType(_Fname, typeof(string)));
        dect.Add("@Lname",      (T)Convert.ChangeType(_Lname, typeof(string)));
        dect.Add("@Login",      (T)Convert.ChangeType(_Login, typeof(string)));
        dect.Add("@Password",   (T)Convert.ChangeType(_Pass,  typeof(string)));
        dect.Add("@Email",      (T)Convert.ChangeType(_Email, typeof(string)));
        dect.Add("@Function",   (T)Convert.ChangeType(_Funct, typeof(string)));

        bool res = SQLsharp<T>.Instance.requestExec(req, dect);
        closeDb();

        return res;
    }

    /// <summary>
    /// Permet de générer un HASH MD5
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public override string generateMD5(string password)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            string hash = GetMd5Hash(md5Hash, password);

            Console.WriteLine("The MD5 hash of " + password + " is: " + hash + ".");

            Console.WriteLine("Verifying the hash...");

            if (VerifyMd5Hash(md5Hash, password, hash))
            {
                Console.WriteLine("The hashes are the same.");
                return hash;
            }
            else
            {
                Console.WriteLine("The hashes are not same.");
                return "NULL";
            }
        }
    }

    /// <summary>
    /// Recupére le HASH md5 d'un string
    /// </summary>
    /// <param name="md5Hash"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public override string GetMd5Hash(MD5 md5Hash, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    /// <summary>
    /// Verifier un Hash via un string
    /// </summary>
    /// <param name="md5Hash"></param>
    /// <param name="input"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public override bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
    {
        // Hash the input.
        string hashOfInput = GetMd5Hash(md5Hash, input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Affiches les attributs de l'utilisateur courant
    /// </summary>
    public override void Display()
    {
        Console.WriteLine ("* Member INFORMATIONS * ");
        Console.WriteLine ("Id       |" + this.Id);
        Console.WriteLine ("function |" + this.Function);
        Console.WriteLine ("Fname    |" + this.Fname);
        Console.WriteLine ("Lname    |" + this.Lname);
        Console.WriteLine ("Login    |" + this.Login);
        Console.WriteLine ("Password |" + this.Password);
        Console.WriteLine ("email    |" + this.Email);
        Console.WriteLine ("* * * * * * * * * * * ");
    }
    #endregion 
}

