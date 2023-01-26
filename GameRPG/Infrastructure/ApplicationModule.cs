using Autofac;
using GameRPG.Domain.Interfaces;
using GameRPG.Repository.Repository;

namespace GameRPG.Infrastructure
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Repository
            builder.RegisterType<ProfessionRepository>()
                     .As<IProfessionRepository>()
                     .InstancePerLifetimeScope();

            builder.RegisterType<CharacterRepository>()
         .As<ICharacterRepository>()
         .InstancePerLifetimeScope();

            #endregion

        }
    }
}
