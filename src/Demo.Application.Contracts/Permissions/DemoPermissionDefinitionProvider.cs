using Demo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Demo.Permissions
{
    public class DemoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DemoPermissions.GroupName);
            var authorsPermission = myGroup.AddPermission(
    DemoPermissions.Authors.Default, L("Permission:Authors"));

            authorsPermission.AddChild(
                DemoPermissions.Authors.Create, L("Permission:Authors.Create"));

            authorsPermission.AddChild(
                DemoPermissions.Authors.Edit, L("Permission:Authors.Edit"));

            authorsPermission.AddChild(
                DemoPermissions.Authors.Delete, L("Permission:Authors.Delete"));
            //Define your own permissions here. Example:
            //myGroup.AddPermission(DemoPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DemoResource>(name);
        }
    }
}
