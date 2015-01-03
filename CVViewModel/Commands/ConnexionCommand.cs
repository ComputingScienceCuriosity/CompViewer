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
        /// Initilise une nouvelle isntance de la classe ConnexionVM
        /// </summary>
        /// <param name="connexionVM"></param>
        public ConnexionCommand(ConnexionVM connexionVM)
        {
            _ViewModel = connexionVM;
        }

        private ConnexionVM _ViewModel;

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
        #endregion

        
    }
}
