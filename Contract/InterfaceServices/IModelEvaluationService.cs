using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.InterfaceServices
{
    public interface IModelEvaluationService
    {
        Task<ModelEvaluationDto> GetModelScore();
    }
}
