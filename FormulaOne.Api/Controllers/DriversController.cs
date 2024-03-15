using AutoMapper;
using FormulaOne.DataSerivce.Repositories.Interfaces;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    public DriversController(IUnitofWork unitofWork, IMapper mapper) : base(unitofWork, mapper)
    {
    }
}