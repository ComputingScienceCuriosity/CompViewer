using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CVViewModel.Commands
{
    internal class ConnexionCommand : ICommand
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe MemberViewModel
        /// </summary>
        /// <param name="connexionVM"></param>
        public ConnexionCommand(MemberViewModel memberVM)
        {
            _ViewModel = memberVM;
        }

        private MemberViewModel _ViewModel;

        #region ICommand Members

        

        public event EventHandler CanExecuteChanged
        {
            add    { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Utilisé pour les controles comme les boutons
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _ViewModel.SaveChages();
        }
        #endregion

        
    }
}
