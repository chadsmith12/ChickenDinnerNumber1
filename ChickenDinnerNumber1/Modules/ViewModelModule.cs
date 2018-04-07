using ChickenDinnerNumber1.ViewModels;
using Ninject.Modules;

namespace ChickenDinnerNumber1.Modules
{
    /// <summary>
    /// Loads the ViewModels into the Kernel.
    /// </summary>
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MainViewModel>().ToSelf();
        }
    }
}
