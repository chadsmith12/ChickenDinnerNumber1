using ChickenDinnerNumber1.DialogService;
using Ninject.Modules;
using Pubg.Net;

namespace ChickenDinnerNumber1.Modules
{
    /// <summary>
    /// Module to bind your services.
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDialogService>().To<DialogService.DialogService>();
            Bind<PubgPlayerService>().ToSelf();
        }
    }
}
