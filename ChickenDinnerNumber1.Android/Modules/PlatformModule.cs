using Ninject.Modules;

namespace ChickenDinnerNumber1.Droid.Modules
{
    /// <summary>
    /// Binds all the Android Platform Specific Modules.
    /// This gets passed into the ap on launch and Forms handles loading it into the kernel.
    /// </summary>
    public class PlatformModule : NinjectModule
    {
        public override void Load()
        {

        }
    }
}