// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructureMapWebApiDependencyScope.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http.Dependencies;
using StructureMap;
#pragma warning disable 1591

namespace StrategyCorps.CodeSample.WebApi.DependencyResolution
{
    /// <summary>
    /// The structure map web api dependency scope.
    /// </summary>
    public class StructureMapWebApiDependencyScope : StructureMapDependencyScope, IDependencyScope
    {
        private IContainer _container;

        public StructureMapWebApiDependencyScope(IContainer container)
            : base(container)
        {
            _container = container;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_container != null)
                {
                    _container.Dispose();
                    _container = null;
                }
            }
        }
    }
}
