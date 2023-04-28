using System.ServiceModel;

namespace WCFClientMaui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        // INFO: to make this work, set the local IP in
        // WCFService1\.VS\WCFService1\config\applicationhost.config
        // 		    <binding protocol="http" bindingInformation="*:63489:192.168.6.36" />
        // and set the path to the website
        //          physicalPath="D:\develop\Dw.automation\Dw.WcfService"

        // to start IISExpress, I run WCFService1\WCFService1\startIISExpress.cmd as administrator

        var wcfClient = new ServiceClient(ServiceClient.EndpointConfiguration.BasicHttpBinding_IService,
            new EndpointAddress("http://192.168.6.36:63489/Service.svc"));

		// various error messages, but I think that's all the same reason
        var s = wcfClient.GetData(++count);

		var ct = wcfClient.GetDataUsingDataContract(new CompositeType() {
			BoolValue = true,
			StringValue = "myString",
		});
		bool b = ct.BoolValue;


		SemanticScreenReader.Announce(s);
	}
}

