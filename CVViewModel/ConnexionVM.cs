using CVViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CVViewModel
{
    public class ConnexionVM 
    {
        private UserConcrete<string> user;

        /// <summary>
        /// Constructeur Par Défault, initialise une nouvelle instance de la classe UserConcrete
        /// </summary>
        public ConnexionVM() 
        {
            user = new UserConcrete<string>(1,"admin","yasser","boudj","paradox","data","data");
           // UpdateCommand = new ConnexionCommand();
            
        }

       
        /// <summary>
        /// Récupérer l'instance de UserConcrete
        /// </summary>
        public UserConcrete<string> User
        {
            get 
            {
                return user;
            }
        }

        /// <summary>
        /// Récupére le UpdateCommand du ViewModel
        /// </summary>
        /// <returns></returns>
      /*  public ICommand UpdateCommand()
        {
            get;
            private set;
        }
        */
        /// <summary>
        /// Sauvegarde les chagements faites sur l'instance UserConcrete
        /// </summary>
        public void SaveChages()
        {
            Debug.Assert(false,string.Format("{0} est mis à jour :", user.Login));
        }

        public string TxtBoxLogin
        {
            get 
            {
                if (user.Login != "")
                    return user.Login;
                else
                    return Convert.ToString(null);
            }
            set
            {
                user.Login = value;
            }
        }

        public string TxtBoxPassword
        {
            get
            {
                if (user.Password != "")
                    return user.Password;
                else
                    return Convert.ToString(null);
            }
            set
            {
                user.Password = value;
            }
        }

        public bool btnConnexion 
        {
            get 
            {
                if (user.checkUser(TxtBoxLogin, TxtBoxPassword))
                {
                    TxtBoxLogin = "YES";
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
