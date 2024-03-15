using AutoMapper;
using FormulaOne.DataSerivce.Repositories.Interfaces;

namespace FormulaOne.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(IUnitofWork unitofWork, IMapper mapper) : base(unitofWork, mapper)
    {
    }
}