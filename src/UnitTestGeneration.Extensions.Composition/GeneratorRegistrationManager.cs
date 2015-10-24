﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestGenerator.UnitTestGeneration;

namespace UnitTestGeneration.Extensions.Composition
{
    class GeneratorRegistrationManager
    {
        private IList<Func<IServiceProvider, ITestMethodGenerator>> generators = new List<Func<IServiceProvider, ITestMethodGenerator>>();

        public void AddGenerator<TGenerator>()
            where TGenerator : ITestMethodGenerator
        {
            generators.Add(x => (ITestMethodGenerator)x.GetService(typeof(TGenerator)));
        }

        public void AddGenerator(ITestMethodGenerator testMethodGenerator)
        {
            generators.Add(x => testMethodGenerator);
        }

        public void AddGenerator(Func<IServiceProvider, ITestMethodGenerator> instanceProducer)
        {
            generators.Add(instanceProducer);
        }

        public IEnumerable<Func<IServiceProvider, ITestMethodGenerator>> GetGenerators()
        {
            return generators;
        }
    }
}
