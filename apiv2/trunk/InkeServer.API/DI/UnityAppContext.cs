using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Practices.Unity;
using Inke.Common;
using InkeServer.DataMapping;

namespace InkeServer.API.DI
{
    public class UnityAppContext : IDisposable
    {
        #region Container

        private Dictionary<string, string> _injectors;
        private Dictionary<string, IUnityContainer> _collection = new Dictionary<string, IUnityContainer>();

        public IUnityContainer this[string name]
        {
            get
            {
                if (_collection.ContainsKey(name))
                    return _collection[name];
                return null;
            }
            set
            {
                if (_collection.ContainsKey(name))
                    _collection[name] = value;
                else
                    _collection.Add(name, value);
            }
        }

        public Dictionary<string, string> Injectors
        {
            get { return _injectors = _injectors ?? new Dictionary<string, string>(); }
        }

        public void InitContainer()
        {
            if (this[ContainerHelper.CONTAINER] == null)
                this[ContainerHelper.CONTAINER] = ContainerHelper.CreateContainer(Injectors);
        }

        public void Register(string interfaceAssembly, string implAssembly)
        {
            Injectors.Add(interfaceAssembly, implAssembly);
        }

        #endregion Container

        #region Singleton Instance

        private static UnityAppContext current;

        /// <summary>
        /// Using Singleton pattern get one and only instance of the class.
        /// </summary>
        public static UnityAppContext Current
        {
            get
            {
                if (current == null)
                    current = new UnityAppContext();

                return current;
            }
        }

        #endregion Singleton Instance

        #region IDisposable Member

        public void Dispose()
        {
            if (this._collection != null)
                this._collection.Clear();

            this._collection = null;
        }

        #endregion IDisposable Member
    };

    /// <summary>
    /// 依赖注入容器配置读取
    /// </summary>
    public class ContainerHelper
    {
        public const string CONTAINER = "DI.Inject";

        public static IUnityContainer CreateContainer(Dictionary<string, string> injectors)
        {
            IUnityContainer container = new UnityContainer();

            //注册Entities
            container.RegisterType(typeof(InkeServerEntities), typeof(InkeServerEntities));

            if (injectors == null || injectors.Count == 0)
                return container;

            foreach (var key in injectors.Keys)
            {
                Assembly interfaceAssembly = Assembly.Load(key);
                Assembly implAssembly = Assembly.Load(injectors[key]);

                var interfaces = interfaceAssembly.GetInterfaces();
                interfaces.ForEach(i =>
                {
                    var curri = i;
                    var impls = implAssembly.GetImplsOfInterface(i);
                    if (impls.Count > 1)
                        impls.ForEach(im => container.RegisterType(curri, im, im.Name));
                    else
                        impls.ForEach(im => container.RegisterType(curri, im));
                });
            }

            return container;
        }
    };
}