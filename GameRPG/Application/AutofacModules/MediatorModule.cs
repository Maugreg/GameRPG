using Autofac;
using GameRPG.Application.Commands.CharacterCommand;
using GameRPG.Application.Commands.ProfessionCommands;
using MediatR;
using System.Reflection;

namespace GameRPG.Application.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
     .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GetProfessionCommand).GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<,>));


            builder.RegisterAssemblyTypes(typeof(GetCharacterCommand).GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CreateCharacterCommand).GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<,>));


            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

        }
    }
}
