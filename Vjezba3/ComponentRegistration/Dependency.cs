﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;


namespace Vjezba3.ComponentRegistration
{
    public class Dependency
    {
        private static IWindsorContainer _container;

        //Initialize the container
        public static void Initialize()
        {
            _container = new WindsorContainer();
            _container.Register(new ComponentRegistration());
        }

        //Resolve types
        public static T For<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
