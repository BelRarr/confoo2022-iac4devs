using Pulumi;
using AzureNative = Pulumi.AzureNative;

class ImportedResourcesStack : Stack
{
    public ImportedResourcesStack()
    {
        var serveursql = new AzureNative.Sql.Server("serveursql", new AzureNative.Sql.ServerArgs
        {
            AdministratorLogin = "tidjani22221",
            Location = "canadacentral",
            PublicNetworkAccess = "Enabled",
            ResourceGroupName = "tidjani-dbscaleup-rg",
            ServerName = "scaleupdbserver",
            Tags =
            {
                { "Environment", "dev" },
            },
            Version = "12.0",
        }, new CustomResourceOptions
        {
            Protect = true,
        });
    }

}