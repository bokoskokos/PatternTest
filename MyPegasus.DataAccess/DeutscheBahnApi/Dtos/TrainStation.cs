using MyPegasus.Common.DomainModel.Models;
using Newtonsoft.Json;

namespace MyPegasus.DataAccess.DeutscheBahnApi.Dtos
{
    public class TrainStation : ITrainStation
    {
        [JsonProperty(PropertyName = "stationNumber")]
        public int StationNumber { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
