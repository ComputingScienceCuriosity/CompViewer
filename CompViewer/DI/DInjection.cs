using Microsoft.Practices.Unity;
using CVViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompViewer.DI
{
    public class DInjection
    {
        private static DInjection instance = null;

        public static DInjection Instance
        {
            get 
            {
                if (instance == null)
                    instance = new DInjection();

                return instance;
            }
        }

        public IUnityContainer unityContainer;

        public DInjection()
        {
            instance = this;
            unityContainer = new UnityContainer();
        }

        public void InjectDependencies()
        { 
            unityContainer.RegisterType<MemberConcrete<string>>();
            unityContainer.RegisterType<ConnexionCommand>();
        }
    }
}
