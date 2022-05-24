using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.InterfaceServices
{
    public interface IModelEvaluationService
    {
        //Interface that demands the method with the following returntype:
        //Task<ModelEvaluationDto>
        Task<ModelEvaluationDto> GetModelScore();
    }
}
