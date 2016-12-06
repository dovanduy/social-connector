namespace App.Common.Tasks.Mapping
{
    using System;
    using System.Linq;
    using App.Common.Mapping;
    using App.Common.Helpers;

    public class AutoMapperConfigurationTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationStartedTask<TaskArgument<System.Web.HttpApplication>>
    {
        public AutoMapperConfigurationTask() : base(ApplicationType.All)
        {
        }

        public override void Execute(TaskArgument<System.Web.HttpApplication> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }
            var types = AssemblyHelper.GetAllApplicationTypes();
            this.ConfigStandardMappings(types.ToArray());
        }

        private void ConfigStandardMappings(Type[] types)
        {
            var maps = (from type in types
                        from i in type.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMappedFrom<>)
                        && !type.IsAbstract && !type.IsInterface
                        select new
                        {
                            Source = i.GenericTypeArguments[0],
                            Dest = type
                        }).ToArray();
            foreach (var map in maps)
            {
                AutoMapper.Mapper.CreateMap(map.Source, map.Dest);
                AutoMapper.Mapper.CreateMap(map.Dest, map.Source);
            }
        }
    }
}