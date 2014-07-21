using PIT.Business.Entities;

namespace PIT.WPF.Core.Contracts
{
    public interface IPITWindowManager
    {
        WindowLocation GetCenteredWindowLocation(double desiredWidth, double desiredHeight);
    }
}
