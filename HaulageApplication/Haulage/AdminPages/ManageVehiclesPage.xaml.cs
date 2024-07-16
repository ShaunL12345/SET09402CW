using Haulage.DatabaseFunctions;

namespace Haulage;

public partial class ManageVehiclesPage : ContentPage
{
	public ManageVehiclesPage()
	{
		InitializeComponent();
		var test = VehicleExecutionService.getVehicles();
    }
	
	
}