using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace Imposto.Core.Factory
{
    public static class Factory
    {
        public static T CreateInstance<T, TR>()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType(typeof(T), typeof(TR));
            return container.Resolve<T>();
        }
    }
}
