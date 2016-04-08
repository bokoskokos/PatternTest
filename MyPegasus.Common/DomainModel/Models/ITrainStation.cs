using Newtonsoft.Json;

namespace MyPegasus.Common.DomainModel.Models
{
    public interface ITrainStation
    {
        int StationNumber { get; }

        string Name { get; }
    }
}
