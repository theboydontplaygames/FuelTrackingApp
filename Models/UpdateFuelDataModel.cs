namespace Fuel_Tracking_application.Models
{
    public class UpdateFuelDataModel
    {
        public Guid dataId { get; set; }

        public string? reportingEmployee { get; set; }

        public DateTime Date { get; set; }

        public int odometerTotal { get; set; }

        public int filledVolume { get; set; }

        public int fuelPrice { get; set; }

        public string? filled { get; set; }
    }
}
