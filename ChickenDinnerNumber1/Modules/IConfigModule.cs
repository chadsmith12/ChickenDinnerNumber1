using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenDinnerNumber1.Modules
{
    /// <summary>
    /// Defines way for to create your own configuration modules to add onto the startup logic.
    /// </summary>
    public interface IConfigModule
    {
        void Load();
    }
}
