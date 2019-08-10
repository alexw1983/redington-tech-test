using RedingtonTechTest.WebAPI.Models;

namespace RedingtonTechTest.WebAPI.Services
{
    public interface IProbabilityCalculationsService
    {
        ProbabilityCalculationsResponseModel CombineAWithB(ProbabilityCalculationsRequestModel input);

        ProbabilityCalculationsResponseModel EitherAOrB(ProbabilityCalculationsRequestModel input);
    }
}