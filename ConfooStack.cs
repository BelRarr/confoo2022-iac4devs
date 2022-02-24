using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;



class ConfooStack : Stack 
{
    public ConfooStack() 
    {
        // gerer la configuration
        var config = new Config("confoovars");    


        // creer un resource group
        var rg = new ResourceGroup("confoorg", new ResourceGroupArgs(){
            ResourceGroupName = config.Require("rgName"), //"confoo-rg",
            Location = "canadacentral"
        });


        // creer un plan de service
        var plan = new AppServicePlan("confooplan", new AppServicePlanArgs(){
            Name = "confooplan",
            Location = rg.Location,
            ResourceGroupName = rg.Name,
            Kind = "App",
            Sku = new SkuDescriptionArgs(){
                Name = "B1",
                Tier = "Basic"
            }
        });

        // creer une web app
        var webapp = new WebApp("confooweb", new WebAppArgs(){
            Name = config.Require("webappName"), //"webappconfoo",
            Location = plan.Location,
            ResourceGroupName = rg.Name,
            ServerFarmId = plan.Id,
            HttpsOnly = false
        });

        WebAppHostname = webapp.DefaultHostName.Apply(host => "https://" + host);
    }


    [Output]
    public Output<string> WebAppHostname { get; set; }
}