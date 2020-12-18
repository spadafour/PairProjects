using System.Collections.Generic;

namespace PetElevator.Shared
{
    public interface IBillable
    {
        double GetBalanceDue(Dictionary<string, double> servicesRendered);
    }
}
