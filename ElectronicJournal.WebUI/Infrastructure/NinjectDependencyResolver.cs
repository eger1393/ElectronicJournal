﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using ElectronicJournal.Domain.Concrete;
using ElectronicJournal.Domain.Abstract;

namespace ElectronicJournal.WebUI.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel kernel;
		private void bind()
		{
			kernel.Bind<IStudentRepository>().To<EFStudentRepository>();

            kernel.Bind<ITroopRepository>().To<EFTroopRepository>();
            kernel.Bind<IPrepodRepository>().To<EFPrepodRepository>();
            kernel.Bind<IDisciplineRepository>().To<EFDisciplineRepository>();
        }
		public NinjectDependencyResolver(IKernel kernelParam)
		{
			kernel = kernelParam;
			bind();
		}


		public object GetService(Type serviceType)
		{
			return kernel.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return kernel.GetAll(serviceType);
		}
	}
}