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
    public class MemberViewModel 
    {
        private MemberConcrete<string> member;

        /// <summary>
        /// Constructeur Par Défault, initialise une nouvelle instance de la classe UserConcrete
        /// </summary>
        public MemberViewModel() 
        {
            member            = new MemberConcrete<string>();
            UpdateCommand     = new ConnexionCommand(this);
        }

        /// <summary>
        /// Get/Set une valeur booléene indiquant comment la connexion peut étre modifié (ex : état IsEnabled)
        /// </summary>
        public bool CanUpdate 
        {
            get 
            {
                if (member == null)
                    return false;

                return !(string.IsNullOrWhiteSpace(member.Login) && string.IsNullOrWhiteSpace(member.Password));
            } 
        }
       
        /// <summary>
        /// Récupérer l'instance de UserConcrete
        /// </summary>
        public MemberConcrete<string> Member
        {
            get 
            {
                return member;
            }
        }

        /// <summary>
        /// Récupére le UpdateCommand du ViewModel
        /// </summary>
        /// <returns></returns>
        public ICommand UpdateCommand
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Sauvegarde les chagements faites sur l'instance UserConcrete
        /// </summary>
        public void SaveChages()
        {
            Debug.Assert(false, "Connexion State : "+CheckMember.ToString());
        }

        /// <summary>
        /// Vérifie l'utilisateur avec le Login, Password passés par Binding
        /// </summary>
        public bool CheckMember 
        {
            get 
            {
                if (member.checkMember(member.Login, member.Password))
                    return true;
                
                else
                    return false;
            }
        }
    }
}
